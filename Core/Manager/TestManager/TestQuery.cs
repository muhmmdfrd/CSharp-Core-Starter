using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Manager.TestManager
{
	public class TestQuery : IDisposable
	{
		private readonly FirstStoreContext _db;

		public TestQuery(FirstStoreContext db)
		{
			_db = db;
		}

		private async Task<IQueryable<Test>> GetQuery()
		{
			return _db.Tests.Select(x => new Test()
			{
				Id = x.Id,
				Age = x.Age,
				JoinDate = x.JoinDate,
				Name = x.Name
			});
		}

		public async Task<List<Test>> GetList()
		{
			var query = await GetQuery();

			return query.ToList();
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
