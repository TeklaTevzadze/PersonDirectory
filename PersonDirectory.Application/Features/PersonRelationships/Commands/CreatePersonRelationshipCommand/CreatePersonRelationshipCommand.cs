using MediatR;
using PersonDirectory.Application.Enum;

namespace PersonDirectory.Application.Features.PersonRelationships.Commands.CreatePersonRelationshipCommand
{
    public class CreatePersonRelationshipCommand : IRequest
    {
        public RelationshipTypeEnum RelationshipType { get; set; }
        public int RelatedToPersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}
