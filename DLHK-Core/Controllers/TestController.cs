using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DLHK_Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly ITestService _testService;

		public TestController(ITestService testService)
		{
			_testService = testService;
		}

		public async Task<object> Get()
		{
			try
			{
				var result = await _testService.Get();

				return ApiResponse.Success(result);
			}
			catch (Exception ex)
			{
				return ApiResponse.Error(ex.Message);
			}
		}
	}
}
