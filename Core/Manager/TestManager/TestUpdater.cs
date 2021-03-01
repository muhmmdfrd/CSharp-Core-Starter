using Core.Extensions;
using Core.Models;
using Repository.Model;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Manager.TestManager
{
	public class TestUpdater : IDisposable
	{
		private readonly FirstStoreContext _db;

		public TestUpdater(FirstStoreContext db)
		{
			_db = db;
		}

		public async Task Update(Test test)
		{
			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var exist = _db.Tests.Find(test.Id);

				if (exist.IsNull())
					throw new Exception(Message.NotFound("Test"));

				exist.Age = test.Age;
				exist.JoinDate = test.JoinDate;
				exist.Name = test.Name;

				await _db.SaveChangesAsync();

				transaction.Complete();
			}
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
