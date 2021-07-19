using FluentValidation;
using PersonDirectory.Application.Features.PersonRelationships.Commands.DeletePersonRelationshipCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Validators.PersonRelationshipValidators
{
    public class DeletePersonRelationshipValidator : AbstractValidator<DeletePersonRelationshipCommand>
    {
        public DeletePersonRelationshipValidator()
        {
            RuleFor(o => o.Id).NotNull().GreaterThan(0);
        }
    }
}
