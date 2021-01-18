using Core.Interfaces;
using Core.Manager.TestManager;
using Repository.Model;
using System;
using System.Threading.Tasks;

namespace Core.Services
{
	public class TestService : ITestService
	{
		private readonly FirstStoreContext _db;

		public TestService()
		{
			_db = new FirstStoreContext();
		}

		public async Task<object> Get()
		{
			try
			{
				using (var query = new TestQuery(_db))
				{
					return await query.GetList();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
