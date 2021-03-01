namespace Core.Models
{
	public static class Message
	{
		private static readonly string PREFIX = "Data";

		public static string Found()
		{
			return $"{PREFIX} found.";
		}

		public static string Created()
		{
			return $"{PREFIX} Created.";
		}

		public static string Updated()
		{
			return $"{PREFIX} updated.";
		}

		public static string Deleted()
		{
			return $"{PREFIX} deleted";
		}

		public static string NotFound()
		{
			return $"{PREFIX} not found.";	
		}

		public static string NotFound(string module)
		{
			return $"{module} not found.";
		}
	}
}
