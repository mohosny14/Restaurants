using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Authorization;

public class RestaurantsUserClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) 
    : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
{
    // Extend User Claims
    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);

        // Add Nationality for claims
        if (user.Nationality != null)
        {
            id.AddClaim(new Claim(AppCliamTypes.Nationality, user.Nationality));
        }

        // Add DateOfBirth for claims
        if (user.DateOfBirth != null)
        {
            id.AddClaim(new Claim(AppCliamTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
        }

        return new ClaimsPrincipal(id);
    }
}