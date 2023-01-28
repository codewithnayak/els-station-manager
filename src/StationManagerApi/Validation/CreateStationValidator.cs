using FluentValidation;
using StationManagerApi.Models;

namespace StationManagerApi.Validation
{
    public class CreateStationValidator : AbstractValidator<CreateStationRequest>
    {
        public CreateStationValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Station name can not be empty");

            RuleFor(a => a.StateCode)
                .NotEmpty()
                .WithMessage("StateCode can not be empty")
                .Must(name => name.Length <= 4)
                .WithMessage("Statecode can not be more than 4 ");

            RuleFor(a => a.Address).
                NotNull().
                WithMessage("Station needs an address");
        }
    }
}
