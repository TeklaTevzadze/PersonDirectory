using FluentValidation;
using PersonDirectory.Application.Features.Persons.Commands.DeletePersonCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Validators.PersonValidators
{
    public class DeletePersonValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonValidator()
        {
            RuleFor(o => o.Id).NotNull().GreaterThan(0);
        }
    }
}
