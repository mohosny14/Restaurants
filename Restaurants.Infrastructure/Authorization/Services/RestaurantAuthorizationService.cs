using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Authorization.Services;

public class RestaurantAuthorizationService(IUserContext userContext, ILogger<RestaurantAuthorizationService> logger)
    : IRestaurantAuthorizationService
{
    public bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser()!;

        // check 1: Create/Read operations
        if (resourceOperation == ResourceOperation.Create || resourceOperation == ResourceOperation.Read)
        {
            logger.LogInformation("Create/Read operation - successful authorization");
            return true;
        }

        // check 2 Admin user for Delete
        if (resourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin user, Delete operation - successful authorization");
            return true;
        }

        // check 3: Restaurant Owner Delete or Update
        if ((resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update)
            && user.Id == restaurant.OwnerId)
        {
            logger.LogInformation("Restaurant Owner - successful authorization");
            return true;
        }
        return false;
    }
}