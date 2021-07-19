using MediatR;
using PersonDirectory.Application.Features.Persons.Queries.Common;

namespace PersonDirectory.Application.Features.Persons.Queries.GetPersonQuery
{
    public class GetPersonQuery : IRequest<PersonResponse>
    {
        public int Id { get; set; }
    }
}
