using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Commands.Dtos.Restaurants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;

public class GetDishesForRestaurantQueryHandler(ILogger<GetDishesForRestaurantQueryHandler> _logger,IDishesRepository _dishesRepository) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting Dishes for Restaurants...");
        var dishes = await _dishesRepository.GetByIdAsync(request.RestaurantId);

        var dishesDtos = dishes.Select(DishDto.MapDishToDto).ToList();

        if (!dishesDtos.Any())
        {
            _logger.LogWarning("No Dishes found.");
            throw new NotFoundException(nameof(Dish), "All");
        }
        return dishesDtos!;
    }
}