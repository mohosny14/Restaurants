using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(r => r.Name)
            .Length(3, 100).WithMessage("Restaurant name must be between 3 and 100 characters.");
    }
}