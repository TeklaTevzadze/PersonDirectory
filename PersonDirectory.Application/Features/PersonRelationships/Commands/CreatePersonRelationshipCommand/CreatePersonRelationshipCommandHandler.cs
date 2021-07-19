using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Domain.Entities;
using PersonDirectory.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.PersonRelationships.Commands.CreatePersonRelationshipCommand
{
    public class CreatePersonRelationshipCommandHandler : IRequestHandler<CreatePersonRelationshipCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreatePersonRelationshipCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePersonRelationshipCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.Include(x => x.RelatedPersons).FirstOrDefaultAsync(x => x.Id == request.RelatedToPersonId && x.DateDeleted == null);

            var personRelationship = _mapper.Map<PersonRelationship>(request);
            personRelationship.DateCreated = DateTime.Now;

            person.RelatedPersons.Add(personRelationship);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
