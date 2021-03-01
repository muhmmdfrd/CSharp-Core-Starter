using Repository.Model;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Manager.TestManager
{
	public class TestCreator : IDisposable
	{
		private readonly FirstStoreContext _db;

		public TestCreator(FirstStoreContext db)
		{
			_db = db;
		}

		public async Task Save(Test test)
		{
			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var result = _db.AddAsync(test);
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
