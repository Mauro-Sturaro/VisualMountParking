namespace VisualMountParking
{
	public class CommandUri
	{
		public CommandVerb CommandVerb { get; set; }
		public string Uri { get; set; }
		public string Body { get; set; }
	}

	public enum CommandVerb { Get, Post }
}
