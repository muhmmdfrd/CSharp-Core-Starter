using System;
using System.Threading.Tasks;

namespace Core.Models
{
	public static class TaskRunner
	{
		public async static Task<object> Run(Func<object> method)
		{
			try
			{
				var result = await Execute(method.Invoke());
				return ApiResponse.Success(result);
			}
			catch (Exception ex)
			{
				return ApiResponse.Error(ex.Message);
			}
		}

		public async static Task<object> Run<T>(Func<T, object> method, T data)
		{
			try
			{
				var result = await Execute(method.Invoke(data));
				return ApiResponse.Success(result);
			}
			catch (Exception ex)
			{
				return ApiResponse.Error(ex.Message);
			}
		}

		public async static Task<object> Run<T>(Func<T, object> method, T data, string message = "")
		{
			try
			{
				var result = await Execute(method.Invoke(data), false);
				return ApiResponse.Success(message);
			}
			catch (Exception ex)
			{
				return ApiResponse.Error(ex.Message);
			}
		}

		private async static Task<dynamic> Execute(dynamic value, bool withRetval = true)
		{
			CatchError(value);
			return withRetval ? await value?.Result : null;
		}

		private static void CatchError(dynamic value)
		{
			string err = value.Exception?.InnerException.Message;

			if (!string.IsNullOrEmpty(err))
				throw new Exception(err);
		}
	}
}
