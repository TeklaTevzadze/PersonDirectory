using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.Persons.Commands.DeletePersonCommand
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeletePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.Include(x=>x.RelatedPersons).FirstOrDefaultAsync(x => x.Id == request.Id && x.DateDeleted == null);

            if (person == null)
            {
                throw new ObjectNotFoundException("Person Not Found");
            }

            person.DateDeleted = DateTime.Now;
            
            foreach (var relatedPerson in person.RelatedPersons)
            {
                relatedPerson.DateDeleted = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
