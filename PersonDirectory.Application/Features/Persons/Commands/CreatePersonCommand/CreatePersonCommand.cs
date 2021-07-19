using MediatR;
using PersonDirectory.Application.Models;

namespace PersonDirectory.Application.Features.Persons.Commands.CreatePersonCommand
{
    public class CreatePersonCommand : PersonRequest, IRequest
    {
    }
}
