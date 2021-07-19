using AutoMapper;
using PersonDirectory.Application.Features.Persons.Queries.Common;
using PersonDirectory.Application.Models;
using PersonDirectory.Domain.Entities;
using System.Linq;

namespace PersonDirectory.Application.Mappings.Converters
{
    public class PersonResponseConverter : IMappingAction<Person, PersonResponse>
    {
        public void Process(Person source, PersonResponse destination, ResolutionContext context)
        {
            destination.Gender = source.Gender?.Name;
            destination.PhoneNumbers = source.PhoneNumbers.Select(x => new PhoneNumberResponseModel
            {
                Type = x.PhoneNumberType.Name,
                Number = x.Number
            }).ToList();
            destination.RelatedPersons = source.RelatedPersons.Where(x => x.DateDeleted == null).Select(r => new RelatedPersonResponse
            {
                Id = r.Id,
                RelatedPersonId = r.RelatedPersonId,
                RelationshipType = r.RelationshipType.Name,
                FirstName = r.RelatedPerson.FirstName,
                LastName = r.RelatedPerson.LastName,
                IdentityNumber = r.RelatedPerson.IdentityNumber,
                BirthDate = r.RelatedPerson.BirthDate,
                Gender = r.RelatedPerson.Gender?.Name,
                PhoneNumbers = r.RelatedPerson.PhoneNumbers.Select(x => new PhoneNumberResponseModel
                {
                    Type = x.PhoneNumberType.Name,
                    Number = x.Number
                }).ToList()
            }).ToList();
        }
    }
}
