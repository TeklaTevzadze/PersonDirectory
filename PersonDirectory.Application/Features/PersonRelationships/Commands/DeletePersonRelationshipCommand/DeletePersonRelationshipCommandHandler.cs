using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.PersonRelationships.Commands.DeletePersonRelationshipCommand
{
    public class DeletePersonRelationshipCommandHandler : IRequestHandler<DeletePersonRelationshipCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeletePersonRelationshipCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonRelationshipCommand request, CancellationToken cancellationToken)
        {
            var personRelationship = await _context.PersonRelationships.FirstOrDefaultAsync(x => x.Id == request.Id && x.DateDeleted == null);

            if (personRelationship == null)
            {
                throw new ObjectNotFoundException("Person Relationship Not Found");
            }

            personRelationship.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
