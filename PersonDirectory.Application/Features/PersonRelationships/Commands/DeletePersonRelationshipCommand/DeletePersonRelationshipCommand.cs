using MediatR;

namespace PersonDirectory.Application.Features.PersonRelationships.Commands.DeletePersonRelationshipCommand
{
    public class DeletePersonRelationshipCommand : IRequest
    {
        public int Id { get; set; }
    }
}
