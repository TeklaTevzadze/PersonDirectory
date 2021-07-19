using MediatR;
using PersonDirectory.Application.Enum;
using PersonDirectory.Domain.Entities;
using PersonDirectory.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.System.Commands
{
    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IApplicationDbContext _context;
        public SeedSampleDataCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            if (!_context.Genders.Any())
                await SeedGenderAsync(cancellationToken);
            if (!_context.PhoneNumberTypes.Any())
                await SeedPhoneNumberTypeAsync(cancellationToken);
            if (!_context.RelationshipTypes.Any())
                await SeedRelationshipTypeAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        #region Private
        private async Task SeedRelationshipTypeAsync(CancellationToken cancellationToken)
        {
            var relationshipTypes = new[] {
                new RelationshipType{Id = (int)RelationshipTypeEnum.Colleague, Name= "კოლეგა" },
                new RelationshipType{Id = (int)RelationshipTypeEnum.Familiar, Name= "ნაცნობი" },
                new RelationshipType{Id = (int)RelationshipTypeEnum.Relative, Name= "ნათესავი" },
                new RelationshipType{Id = (int)RelationshipTypeEnum.Other, Name= "სხვა" }
            };
            await _context.RelationshipTypes.AddRangeAsync(relationshipTypes, cancellationToken);
        }

        private async Task SeedPhoneNumberTypeAsync(CancellationToken cancellationToken)
        {
            var phoneNumberTypes = new[] {
                new PhoneNumberType{Id = (int)PhoneNumberTypeEnum.Mobile, Name= "მობილური" },
                new PhoneNumberType{Id = (int)PhoneNumberTypeEnum.Office, Name= "ოფისი" },
                new PhoneNumberType{Id = (int)PhoneNumberTypeEnum.Home, Name= "სახლი" }
            };
            await _context.PhoneNumberTypes.AddRangeAsync(phoneNumberTypes, cancellationToken);
        }

        private async Task SeedGenderAsync(CancellationToken cancellationToken)
        {
            var genders = new[] {
                new Gender{Id = (int)GenderEnum.Female, Name= "ქალი" },
                new Gender{Id = (int)GenderEnum.Male, Name= "კაცი" }
            };
            await _context.Genders.AddRangeAsync(genders, cancellationToken);
        }
        #endregion
    }
}
