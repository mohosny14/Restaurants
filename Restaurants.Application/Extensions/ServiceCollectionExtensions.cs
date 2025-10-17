using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.IServices;
using Restaurants.Application.Services;
using FluentValidation;
using Restaurants.Application.Validators;
using FluentValidation.AspNetCore;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddScoped<IRestaurantsService, RestaurantsService>();

            services.AddValidatorsFromAssembly(assembly)
                .AddFluentValidationAutoValidation();

            return services;
        }
    }
}