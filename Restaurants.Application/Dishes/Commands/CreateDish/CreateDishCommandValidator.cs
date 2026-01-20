using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
	public CreateDishCommandValidator()
	{
		RuleFor(d => d.Price)
			.GreaterThanOrEqualTo(0)
			.WithMessage("Perice must be a non-negative number.");

        RuleFor(d => d.KiloCalories)
            .GreaterThanOrEqualTo(0)
            .WithMessage("KiloCalories must be a non-negative number.");
    }
}