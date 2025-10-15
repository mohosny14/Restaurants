using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.IServices;
using Restaurants.Application.Services;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantsService, RestaurantsService>();

            return services;
        }
    }
}