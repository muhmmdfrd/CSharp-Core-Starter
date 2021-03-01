using Core.Manager.TestManager;
using Repository.Model;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface ITestService
	{
		Task<object> Get();
		Task<object> GetPaged(TestFilter filter);
		Task Post(Test test);
		Task Update(Test test);
		Task Delete(long id);
	}
}
