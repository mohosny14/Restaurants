using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Restaurants.Application.Users
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User context is not present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }
            var userId = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(u => u.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(u => u.Type == ClaimTypes.Role)!.Select(u => u.Value);

            var nationality = user.FindFirst(u => u.Type == "Nationality")!.Value;
            var DateOfBirthString = user.FindFirst(u => u.Type == "DateOfBirth")!.Value;
            var DateOfBirth = DateOfBirthString == null 
                    ? (DateOnly?)null 
                    : DateOnly.ParseExact(DateOfBirthString, "yyyy-MM-dd");

            return new CurrentUser(userId, email, roles, nationality, DateOfBirth);
        }
    }
}