using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.Restaurants.Commands.UploadRestaurantLogos;

public class UploadRestaurantLogoCommandHandler(ILogger<UploadRestaurantLogoCommandHandler> logger,
    IRestaurantsRepository _restaurantsRepository,
    IBlobStorageService _blobStorageService)

    : IRequestHandler<UploadRestaurantLogoCommand>
{

    public async Task Handle(UploadRestaurantLogoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Uploading restaurant logos is not implemented yet for Id: {RestaurantId}", request.RestaurantId);
        var restaurant = await _restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        // TODO: Authorize

        // Upload logos to blob storage
        var logoUrl = await _blobStorageService.UploadToBlobAsync(request.File, request.FileName);
        restaurant.LogoUrl = logoUrl;

        await _restaurantsRepository.SaveChanges();
    }
}