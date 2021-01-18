namespace Core.Models
{
	public static class ApiResponse
	{
		public static object Success(object value)
		{
			return new Response()
			{
				Message = "success",
				Success = true,
				Result = value
			};
		}

		public static object Success(string message, object value)
		{
			return new Response()
			{
				Message = message,
				Success = true,
				Result = value
			};
		}

		public static object Error(string message)
		{
			return new Response()
			{
				Message = message,
				Success = false,
				Result = ""
			};
		}
	}

	sealed class Response
	{
		public string Message { get; set; }
		public bool Success { get; set; }
		public object Result { get; set; }
	}
}
