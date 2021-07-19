using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Application.Features.Persons.Queries.Common;
using PersonDirectory.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.Persons.Queries.GetPersonQuery
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetPersonQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PersonResponse> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Persons.Include(x => x.Gender).Include(x => x.PhoneNumbers).ThenInclude(x => x.PhoneNumberType)
                .Include(x => x.RelatedPersons).ThenInclude(x => x.RelatedPerson).ThenInclude(x => x.PhoneNumbers).ThenInclude(x => x.PhoneNumberType)
                .Include(x => x.RelatedPersons).ThenInclude(x => x.RelationshipType).Include(x => x.RelatedPersons).ThenInclude(x => x.RelatedPerson).ThenInclude(x => x.Gender)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.DateDeleted == null, cancellationToken: cancellationToken);

            if (data == null)
            {
                throw new ObjectNotFoundException("Person Not Found");
            }

            var result = _mapper.Map<PersonResponse>(data);

            return result;
        }
    }
}
