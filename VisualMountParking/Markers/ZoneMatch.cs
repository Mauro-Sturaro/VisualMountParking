using System;

namespace VisualMountParking
{
	public class ZoneMatch
	{
		public int ZoneId { get; set; }
		public MarkerPoint Source { get; set; }
		public MarkerPoint Target { get; set; }

		public double GetDistance()
		{
			var result = Math.Sqrt( Math.Pow(Source.X-Target.X, 2)+Math.Pow(Source.Y-Target.Y, 2));
			return result;
		}
	}
}
