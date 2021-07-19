using FluentValidation;
using PersonDirectory.Application.Features.PersonRelationships.Commands.CreatePersonRelationshipCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Validators.PersonRelationshipValidators
{
    public class CreatePersonRelationshipValidator : AbstractValidator<CreatePersonRelationshipCommand>
    {
        public CreatePersonRelationshipValidator()
        {
            RuleFor(o => o.RelatedToPersonId).NotNull().GreaterThan(0);
            RuleFor(o => o.RelatedPersonId).NotNull().GreaterThan(0);
            RuleFor(o => o.RelationshipType).NotNull();
        }
    }
}
