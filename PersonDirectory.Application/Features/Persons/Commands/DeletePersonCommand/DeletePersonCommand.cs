using MediatR;

namespace PersonDirectory.Application.Features.Persons.Commands.DeletePersonCommand
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
