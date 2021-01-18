using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Repository.Model;

namespace Core.Extensions
{
	public static class ServiceConfigurationExtension
	{
		public static void ConfigureService(this IServiceCollection services)
		{
			services.AddScoped<ITestService, TestService>();
		}

		public static void ConnectToContext(this IServiceCollection services)
		{
			services.AddDbContext<FirstStoreContext>();
		}
	}
}
