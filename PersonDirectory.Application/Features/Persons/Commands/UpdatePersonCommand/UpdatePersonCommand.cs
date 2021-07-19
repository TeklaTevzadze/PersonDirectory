using MediatR;
using PersonDirectory.Application.Models;

namespace PersonDirectory.Application.Features.Persons.Commands.UpdatePersonCommand
{
    public class UpdatePersonCommand : PersonRequest, IRequest
    {
        public int Id { get; set; }
    }
}
