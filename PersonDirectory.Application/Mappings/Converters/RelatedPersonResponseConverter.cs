using AutoMapper;
using PersonDirectory.Application.Models;
using PersonDirectory.Domain.Entities;
using System.Linq;

namespace PersonDirectory.Application.Mappings.Converters
{
    public class RelatedPersonResponseConverter : ITypeConverter<PersonRelationship, RelatedPersonResponse>
    {
        public RelatedPersonResponse Convert(PersonRelationship source, RelatedPersonResponse destination, ResolutionContext context)
        {
            destination = new RelatedPersonResponse
            {
                Id = source.Id,
                RelatedPersonId = source.RelatedPersonId,
                RelationshipType = source.RelationshipType.Name,
                FirstName = source.RelatedPerson.FirstName,
                LastName = source.RelatedPerson.LastName,
                IdentityNumber = source.RelatedPerson.IdentityNumber,
                BirthDate = source.RelatedPerson.BirthDate,
                Gender = source.RelatedPerson.Gender?.Name,
                PhoneNumbers = source.RelatedPerson.PhoneNumbers.Select(x => new PhoneNumberResponseModel
                {
                    Type = x.PhoneNumberType.Name,
                    Number = x.Number
                }).ToList()
            };

            return destination;
        }
    }
}

