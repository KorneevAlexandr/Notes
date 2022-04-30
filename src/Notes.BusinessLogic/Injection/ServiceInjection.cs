using Microsoft.Extensions.DependencyInjection;
using Notes.BusinessLogic.Intefaces.Services;
using Notes.BusinessLogic.Services;
using Notes.DataAccess.Injection;

namespace Notes.BusinessLogic.Injection
{
	public static class ServiceInjection
	{
		public static IServiceCollection ServiceInject(this IServiceCollection services, string connectionString)
		{
			services.RepositoryInject(connectionString);
			services.AddScoped<INoteService, NoteService>();

			return services;
		}
	}
}
