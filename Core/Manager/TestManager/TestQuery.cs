using Core.Extensions;
using Core.Models;
using Microsoft.EntityFrameworkCore;
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
			_db =  db;
		}

		private async Task<IQueryable<TestDTO>> GetQuery()
		{
			return _db.Tests.AsNoTracking().Select(x => new TestDTO()
			{
				Id = x.Id,
				Age = x.Age,
				JoinDate = x.JoinDate,
				Name = x.Name
			});
		}

		public async Task<List<TestDTO>> GetList()
		{
			var query = await GetQuery();
			return await query.ToListAsync();
		}

		public async Task<Pagination<TestDTO>> GetPaging(TestFilter filter)
		{
			var query = await GetQuery();
			int total = query.Count();
			int filtered = total;

			if (filter.Id > 0)
			{
				query = query.Where(x => x.Id == filter.Id);
				filtered = query.Count();

				if (filtered.IsZero())
					throw new Exception(Message.NotFound("Test"));
			}

			if (!string.IsNullOrEmpty(filter.Keyword))
			{
				query = query.Where(x => x.Name.Contains(filter.Keyword));
				filtered = query.Count();
			}

			query = query
				.OrderBy(x => x.Id)
				.Skip(filter.Skip)
				.Take(filter.PageSize);

			return new Pagination<TestDTO>()
			{
				Data = query.ToList(),
				Filtered = filtered,
				PageSize = filter.PageSize,
				Total = total
			};
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
