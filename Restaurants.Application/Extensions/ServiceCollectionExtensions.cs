using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;

            // Register AddMediatR handlers from the current assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly)
                .AddFluentValidationAutoValidation();

            return services;
        }
    }
}