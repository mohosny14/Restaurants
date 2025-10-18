using FluentValidation;
namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> allowedCategories = ["Italian", "Chinese", "Mexican", "Indian", "French", "Japanese", "Mediterranean", "American", "Spanish"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Restaurant name is required.")
            .Length(3, 100).WithMessage("Restaurant name must not exceed 100 characters.");

        // Optional: Validate that the category is one of the allowed categories
        // Custom validation rule for category
        RuleFor(dto => dto.Category)
            .Must(allowedCategories.Contains)
            //.Must(category => allowedCategories.Contains(category)) // can be like this too
            .WithMessage($"Category must be one of the following: {string.Join(", ", allowedCategories)}");

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(dto => dto.Category)
            .NotEmpty().WithMessage("Category is required.");

        RuleFor(dto => dto.ContactEmail)
            .NotEmpty().WithMessage("Contact email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        /* valid contact numbers examples:
        +201012345678
        +201555666777
        01012345678
        01555666777
        */
        RuleFor(dto => dto.ContactNumber)
            .NotEmpty().WithMessage("Contact number is required.")
            .Matches(@"^(?:\+201\d{9}|01\d{9})$").WithMessage("A valid contact number is required.");

        RuleFor(dto => dto.PostalCode)
             .Matches(@"^[1-9]\d{4}$")
            .WithMessage("Postal code must be a 5-digit number.");
    }
}