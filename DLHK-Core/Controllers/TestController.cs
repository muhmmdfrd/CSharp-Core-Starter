using Core.Interfaces;
using Core.Manager.TestManager;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Model;
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

		[HttpGet]
		public async Task<object> Get()
		{
			return await TaskRunner.Run(_testService.Get);
		}

		[HttpPost]
		[Route("paged")]
		public async Task<object> GetPaged([FromBody] TestFilter filter)
		{
			return await TaskRunner.Run(_testService.GetPaged, filter);
		}

		[HttpPost]
		public async Task<object> Post([FromBody] Test test)
		{
			return await TaskRunner.Run(_testService.Post, test, Message.Created());
		}

		[HttpPut]
		public async Task<object> Put([FromBody] Test test)
		{
			return await TaskRunner.Run(_testService.Update, test, Message.Updated());
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<object> Delete([FromRoute] long id)
		{
			return await TaskRunner.Run(_testService.Delete, id, Message.Deleted());
		}
	}
}
