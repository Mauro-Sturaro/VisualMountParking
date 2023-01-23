namespace VisualMountParking
{
	public struct Zone
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		internal bool IsEmpty()
		{
			return X == 0 && Y == 0 && Width == 0 && Height == 0;
		}
	}
}
