using MediatR;
using Restaurants.Application.Restaurants.Commands.Dtos.Restaurants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly IBlobStorageService _blobStorageService;

    public GetRestaurantByIdQueryHandler(IRestaurantsRepository restaurantsRepository,IBlobStorageService blobStorageService)
    {
        _restaurantsRepository = restaurantsRepository;
        _blobStorageService = blobStorageService;
    }
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantsRepository.GetRestaurantById(request.Id);
        var restaurantDto = RestaurantDto.MapRestaurantToDto(restaurant) 
                    ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        restaurantDto.LogoSasUrl =  _blobStorageService.GetBlobSasUrl(restaurant.LogoUrl);

        return restaurantDto;
    }
}