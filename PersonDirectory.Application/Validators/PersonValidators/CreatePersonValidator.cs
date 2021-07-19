using FluentValidation;
using PersonDirectory.Application.Features.Persons.Commands.CreatePersonCommand;

namespace PersonDirectory.Application.Validators.PersonValidators
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand> 
    {
        public CreatePersonValidator()
        {
            RuleFor(o => o).SetValidator(new PersonBaseValidator());
        }
    }
}
