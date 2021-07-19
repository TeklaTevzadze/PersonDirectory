using AutoMapper;
using MediatR;
using PersonDirectory.Domain.Entities;
using PersonDirectory.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.Persons.Commands.CreatePersonCommand
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreatePersonCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);
            await _context.Persons.AddAsync(person, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
