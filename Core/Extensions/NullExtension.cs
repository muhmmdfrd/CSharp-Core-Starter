namespace Core.Extensions
{
	public static class NullExtension
	{
		public static bool IsNull(this object value)
		{
			return value == null;
		}
	}
}
