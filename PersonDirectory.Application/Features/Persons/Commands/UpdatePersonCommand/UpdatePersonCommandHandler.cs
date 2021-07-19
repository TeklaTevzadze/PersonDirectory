using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.Persons.Commands.UpdatePersonCommand
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdatePersonCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.Include(o => o.PhoneNumbers).FirstOrDefaultAsync(x => x.Id == request.Id && x.DateDeleted == null, cancellationToken: cancellationToken);

            if (person == null)
            {
                throw new ObjectNotFoundException("Person Not Found");
            }

            _mapper.Map(request, person);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
