using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace VisualMountParking
{
    internal class MyTelescope
    {
        Telescope _Telescope;
        public MyTelescope() { }

        public bool IsTelescopeConnected => _Telescope != null && _Telescope.Connected;

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

        internal void Disconnect()
        {
            if (_Telescope != null)
            {
                _Telescope.Connected = false;
                _Telescope.Dispose();
                _Telescope = null;
            }
        }

        internal void Initialize(string telescopeDriver)
        {
            Disconnect();
            if (!string.IsNullOrWhiteSpace(telescopeDriver))
            {
                _Telescope = new Telescope(telescopeDriver);
                _Telescope.Connected = true;
            }
        }

        internal void StopAnyMovement()
        {

            if (!IsTelescopeConnected)
                return;
            try
            {
                _Telescope.AbortSlew();
            } catch { }
            if (_Telescope.CanSetTracking)
                _Telescope.Tracking = false;
        }

        public async Task RotateAxisAsync(TelescopeAxes axis, double rate, double time, CancellationToken cancellationToken)
        {
            if (!IsTelescopeConnected)
                throw new InvalidOperationException("Mount not connected");

            if (_Telescope.AtPark)
                throw new InvalidOperationException("Mount is At Park");

            var validRate = AdjustTelescopeRate(axis, rate);
            Debug.WriteLine($"Axis {axis}, desiredRate={rate}, validRate={validRate}");

            cancellationToken.ThrowIfCancellationRequested();

            var delay = (int)(time * 100);
            try
            {
                _Telescope.MoveAxis(axis, validRate);
                await Task.Delay(delay, cancellationToken);
            }
            finally
            {
                _Telescope.MoveAxis(axis, 0);
                await Task.Delay(100, cancellationToken);
                if (_Telescope.Slewing)
                {
                    _Telescope.AbortSlew();
                    Debug.WriteLine("ERROR: Move 0 failed");
                }
            }
        }

        Dictionary<TelescopeAxes, IAxisRates> _ValidRates = new Dictionary<TelescopeAxes, IAxisRates>();

        private double AdjustTelescopeRate(TelescopeAxes axis, double desiredRate)
        {
            double maxInf = 0;
            double minSup = int.MaxValue;
            double sign = Math.Sign(desiredRate);
            desiredRate = Math.Abs(desiredRate);


            var allowedRates = GetTelescopeRates(axis);

            foreach (IRate rate in allowedRates)
            {
                if (rate.Minimum <= desiredRate && desiredRate <= rate.Maximum)
                    return sign * desiredRate; // the desired rate is inside an allowed interval

                if (rate.Minimum > desiredRate && rate.Minimum < minSup)
                    minSup = rate.Minimum;
                else if (rate.Maximum < desiredRate && rate.Maximum > maxInf)
                    maxInf = rate.Maximum;
            }

            // the desiredRate is NOT valid, calculate the nearest valid value
            if ((desiredRate - maxInf) < (minSup - desiredRate))
                return sign * maxInf;
            else
                return sign * minSup;
        }

        private IAxisRates GetTelescopeRates(TelescopeAxes axis)
        {
            IAxisRates allowed;
            if (!_ValidRates.TryGetValue(axis, out allowed))
            {
                allowed = _Telescope.AxisRates(axis);
                _ValidRates.Add(axis, allowed);
            }
            return allowed;
        }

        public async Task ParkTelescope()
        {
            if (!IsTelescopeConnected)
                return;
            bool isTrackingStatus = _Telescope.CanSetTracking && _Telescope.Tracking;
            if (_Telescope.AtPark && !isTrackingStatus)
                return;

            if (_Telescope.AtPark) // is at park but Tracking is on, clean up tis strange situation
            {
                _Telescope.Unpark();
            }
            _Telescope.Tracking = false; // valid only when unparked
            await Task.Run(() =>
            {
                Debug.WriteLine($"[{DateTime.Now}]Start Park command");
                _Telescope.Park();
                Debug.WriteLine($"[{DateTime.Now}]End Park command");
            });

        }
        public void UnParkTelescope()
        {
            if (!IsTelescopeConnected || !_Telescope.AtPark)
                return;

            _Telescope.Unpark();
            _Telescope.Tracking = false;
        }
    }


}
