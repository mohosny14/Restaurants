using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;

namespace Restaurants.Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger,
    IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("User: {Email}, date of birth {DOB} - Handling MinimumAgeRequirement",
            currentUser?.Email, currentUser?.DateOfBirth);

        if (currentUser?.DateOfBirth == null)
        {
            logger.LogWarning("User date of birth is NULL");
            context.Fail();
            return Task.CompletedTask;
        }
        if (currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
        {
            logger.LogInformation("Authorization Succeeded");
            context.Succeed(requirement);
        }
        else
        {
            logger.LogInformation("Authorization Failed");
            context.Fail();
        }
        return Task.CompletedTask;
    }
}