using Disney.Application.Contracts.Persistence;
using Disney.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Disney.Persistence
{
    public static class PesistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<DisneyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DisneyConnectionString")));
           

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            return services;
        }
    }
}
