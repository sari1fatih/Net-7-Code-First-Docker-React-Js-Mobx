using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Features.Entity;
using RealEstate.Application.Features.EntityGroup;
using RealEstate.Application.Features.Product;
using RealEstate.Application.Interfaces.Application.Features.Entity;
using RealEstate.Application.Interfaces.Application.Features.EntityGroup;
using RealEstate.Application.Interfaces.Application.Features.Product;

namespace RealEstate.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IEntityManager, EntityManager>();
            services.AddScoped<IEntityGroupManager, EntityGroupManager>();
            services.AddScoped<IProductManager, ProductManager>();
        }
    }
}

