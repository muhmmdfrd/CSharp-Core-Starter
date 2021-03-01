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

		public async Task<object> GetPaged(TestFilter filter)
		{
			try
			{
				using (var query = new TestQuery(_db))
				{
					return await query.GetPaging(filter);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task Post(Test test)
		{
			try
			{
				using (var creator = new TestCreator(_db))
				{
					await creator.Save(test);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task Update(Test test)
		{
			try
			{
				using (var updater = new TestUpdater(_db))
				{
					await updater.Update(test);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task Delete(long id)
		{
			try
			{
				using (var deleter = new TestDeleter(_db))
				{
					await deleter.Delete(id);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
