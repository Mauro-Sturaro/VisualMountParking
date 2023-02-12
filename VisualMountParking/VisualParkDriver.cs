using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace VisualMountParking
{
	public class VisualParkDriver
	{
		Telescope _Telescope;
		PatternVerifier _PatternVerifier = new PatternVerifier();
		Config _Config;
		WebUtils _WebUtils = new WebUtils();

		public Bitmap CurrentImage { get; private set; }

		public void Initialize(Config config)
		{
			_Config = config;
			_PatternVerifier.Initialize(config);
		}

		public void ConnectTelescope()
		{
			DisconnectTelescope();
			if (!string.IsNullOrWhiteSpace(_Config.TelescopeDriver))
			{
				_Telescope = new Telescope(_Config.TelescopeDriver);
				_Telescope.Connected = true;
			}
		}

		public void DisconnectTelescope()
		{
			if (_Telescope != null)
			{
				_Telescope.Connected = false;
				_Telescope.Dispose();
				_Telescope = null;
			}
		}

		public void StopTelescope()
		{
			if (!IsTelescopeConnected)
				return;
			_Telescope.AbortSlew();
			if (_Telescope.CanSetTracking)
				_Telescope.Tracking = false;
		}

		public async Task ParkTelescope()
		{
			if (!IsTelescopeConnected)
				return;
			bool badTrackingStatus = _Telescope.CanSetTracking && _Telescope.Tracking;
			if (_Telescope.AtPark && !badTrackingStatus)
				return;

			if (_Telescope.AtPark) // is at park but Tracking is on, clean up tis strange situation
			{
				_Telescope.Unpark();
			}
			_Telescope.Tracking = false; // valid only when unparked
			await Task.Run(() => _Telescope.Park());

		}
		public void UnParkTelescope()
		{
			if (!IsTelescopeConnected || !_Telescope.AtPark)
				return;

			_Telescope.Unpark();
			_Telescope.Tracking = false;
		}

		public bool IsTelescopeConnected => _Telescope != null && _Telescope.Connected;

		public async Task RotateAxis(TelescopeAxes axis, decimal rate, decimal time, CancellationToken cancellationToken)
		{
			if (!IsTelescopeConnected)
				throw new InvalidOperationException("Mount not connected");

			if (_Telescope.AtPark)
				throw new InvalidOperationException("Mount is At Park");

			cancellationToken.ThrowIfCancellationRequested();

			var delay = (int)(time * 100);
			_Telescope.MoveAxis(axis, (double)rate);
			await Task.Delay(delay, cancellationToken);
			_Telescope.MoveAxis(axis, 0);
		}

		public TelescopeState TelescopeState
		{
			get
			{
				if (!IsTelescopeConnected)
					return TelescopeState.Disconnected;
				if (_Telescope.AtPark)
					return TelescopeState.AtPark;
				if (_Telescope.Slewing || _Telescope.Tracking)
					return TelescopeState.Moving;
				return TelescopeState.Quiet;
			}
		}

		public Action<string> Logger { get; set; }

		private void LogWriteLine(string message)
		{
			if (Logger == null)
				return;
			Logger(message);
			Logger("\r\n");
		}

		private async Task<bool> AutoPark(TelescopeAxes axis, decimal moveRate, decimal moveTime, int zoneId, ShiftDirection direction, CancellationToken cancellationToken)
		{
			if (!IsTelescopeConnected)
				return false;
			//
			//	First movement: proportional to current position delta
			//

			var delta = await GetZoneDelta(zoneId, direction);
			if (!delta.HasValue)
			{
				LogWriteLine("GetZoneDelta failed!");
				return false;
			}

			LogWriteLine($"delta={delta}");
			int nochangeRetry = 3;

			while (!cancellationToken.IsCancellationRequested && delta != 0)
			{
				//cancellationToken.ThrowIfCancellationRequested();
				var pn = Math.Sign(delta.Value);

				decimal rate = -moveRate * pn;
				decimal time = moveTime * Math.Abs(delta.Value);
				LogWriteLine($"RotateAxis({axis},{rate},{time})");
				await RotateAxis(axis, rate, time, cancellationToken);
				await UpdateImageAndPosition();

				var newDelta = await GetZoneDelta(zoneId, direction);
				if (!newDelta.HasValue)
				{
					LogWriteLine("GetZoneDelta(new) failed!");
					return false;
				}

				// check any change
				if (newDelta == delta)
				{
					nochangeRetry--;
					if (nochangeRetry > 0)
					{
						LogWriteLine("No change -> retry");
						continue;
					}
					else
					{
						LogWriteLine("Failed after retry");
						return false;
					}
				}
				else
					nochangeRetry = 3;

				// check progress
				var success = Math.Sign(delta.Value) > 0 ? newDelta < delta : newDelta > delta;
				if (!success)
				{
					LogWriteLine($"Failed: old delta={delta}, newDelta={newDelta}");
					return false;
				}
				LogWriteLine($"Step Ok: old delta={delta}, newDelta={newDelta}");
				delta = newDelta;
			}
			if (delta == 0)
			{
				LogWriteLine("Finish");
				return true;
			}
			return false;
		}

		private async Task<int?> GetZoneDelta(int zoneId, ShiftDirection direction)
		{
			await UpdateImageAndPosition();
			var zone = _PatternVerifier.ZoneMatchList.Find((z) => z.ZoneId == zoneId);
			if (zone == null) return null;

			var delta = direction == ShiftDirection.X ? zone.Target.X - zone.Source.X : zone.Target.Y - zone.Source.Y;
			return delta;
		}

		public async Task UpdateImageAndPosition()
		{
			await LoadNewImage();
			await CheckPosition();
		}

		private EventHandler _ImageUpdated;
		public event EventHandler ImageUpdated { add { _ImageUpdated += value; } remove { _ImageUpdated -= value; } }

		public async Task<Image> LoadNewImage()
		{
			var image = await _WebUtils.LoadImageAsync(_Config.SourceType, _Config.Source);
			CurrentImage = new Bitmap(image);
			_ImageUpdated?.Invoke(this, EventArgs.Empty);
			_PatternVerifier.NewImage = new Bitmap(image);
			return image;
		}

		public async Task CheckPosition()
		{
			await Task.Run(_PatternVerifier.SearchMatch);
		}

		public async Task<bool> DoVisualPark(CancellationToken cancellationToken)
		{
			// Questi devono stare nei settings
			var apRA = _Config.AutoParkAR;
			var apDec = _Config.AutoParkDec;
			//

			var success = await AutoPark(TelescopeAxes.axisPrimary, _Config.MoveRaRate, _Config.MoveRaTime, apRA.ZoneId, apRA.Direction, cancellationToken);
			if (success)
				success = await AutoPark(TelescopeAxes.axisSecondary, _Config.MoveDecRate, _Config.MoveDecTime, apDec.ZoneId, apDec.Direction, cancellationToken);
			return success;
		}

		internal IList<Zone> GetReferenceZone()
		{
			if (_Config.UseArucoMarkers)
			{
				return _PatternVerifier.ReferenceTemplates;
			}
			else
				return _Config.Templates;
		}

		internal IList<ZoneMatch> GetZoneMatch()
		{
			return _PatternVerifier.ZoneMatchList;
		}
	}
}
