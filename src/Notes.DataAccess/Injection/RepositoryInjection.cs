using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notes.DataAccess.Data;
using Notes.DataAccess.Interfaces.Repositories;
using Notes.DataAccess.Repositories;

namespace Notes.DataAccess.Injection
{
	public static class RepositoryInjection
	{
		public static IServiceCollection RepositoryInject(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<NoteDbContext>(option => option.UseSqlServer(connectionString));
      		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			return services;
		}
	}
}
