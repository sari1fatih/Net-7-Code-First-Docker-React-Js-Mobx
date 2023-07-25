using Common.Classes.ApplicationSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Contexts;
using Persistence.Repositories;
using RealEstate.Application.Interfaces.Persistence.Repositories;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            var appOptions = configuration.GetSection(nameof(AppOptions)).Get<AppOptions>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    appOptions?.ConnectionString ?? "",
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IEntityRepositoryAsync, EntityRepositoryAsync>();
            services.AddTransient<IEntityGroupRepositoryAsync, EntityGroupRepositoryAsync>();
            services.AddTransient<IProductPhotoRepositoryAsync, ProductPhotoRepositoryAsync>();
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();

        }
    }
}

