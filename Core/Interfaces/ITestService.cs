using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface ITestService
	{
		Task<object> Get();
	}
}
