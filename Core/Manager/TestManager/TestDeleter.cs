using Core.Extensions;
using Core.Models;
using Repository.Model;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Manager.TestManager
{
	public class TestDeleter : IDisposable
	{
		private readonly FirstStoreContext _db;

		public TestDeleter(FirstStoreContext db)
		{
			_db = db;
		}

		public async Task Delete(long id)
		{
			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var exist = _db.Tests.Find(id);

				if (exist.IsNull())
					throw new Exception(Message.NotFound("Test"));

				_db.Tests.Remove(exist);
				await _db.SaveChangesAsync();

				transaction.Complete();
			}
		}

		public void Dispose()
		{
			_db.DisposeAsync();
		}
	}
}
