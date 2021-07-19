using FluentValidation;
using PersonDirectory.Application.Features.Persons.Commands.UpdatePersonCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Validators.PersonValidators
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonValidator()
        {
            RuleFor(o => o.Id).NotNull().GreaterThan(0);
            RuleFor(o => o).SetValidator(new PersonBaseValidator());
        }
    }
}
