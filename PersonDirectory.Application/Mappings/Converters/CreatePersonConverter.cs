using AutoMapper;
using PersonDirectory.Application.Features.Persons.Commands.CreatePersonCommand;
using PersonDirectory.Domain.Entities;
using System.Linq;

namespace PersonDirectory.Application.Mappings.Converters
{
    public class CreatePersonConverter : IMappingAction<CreatePersonCommand, Person>
    {
        public void Process(CreatePersonCommand source, Person destination, ResolutionContext context)
        {
            destination.GenderId = (int?)source.Gender;
            destination.PhoneNumbers = source.PhoneNumbers.Select(x => new PhoneNumber
            {
                Number = x.Value,
                PhoneNumberTypeId = (int)x.Type
            }).ToList();
        }
    }
}
