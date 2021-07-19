using AutoMapper;
using PersonDirectory.Application.Features.Persons.Commands.UpdatePersonCommand;
using PersonDirectory.Domain.Entities;
using System.Linq;

namespace PersonDirectory.Application.Mappings.Converters
{
    public class UpdatePersonConverter : IMappingAction<UpdatePersonCommand, Person>
    {
        public void Process(UpdatePersonCommand source, Person destination, ResolutionContext context)
        {
            destination.GenderId = (int?)source.Gender;
            UpdatePersonPhoneNumbers(source, destination);
            AddNewPhoneNumbers(source, destination);
        }

        private void UpdatePersonPhoneNumbers(UpdatePersonCommand source, Person destination)
        {
            foreach (var phoneNumber in destination.PhoneNumbers)
            {
                var sourceNumber = source.PhoneNumbers.Where(x => x.Id != 0).FirstOrDefault(x => x.Id == phoneNumber.Id);
                if (sourceNumber != null)
                {
                    phoneNumber.Number = sourceNumber.Value;
                    phoneNumber.PhoneNumberTypeId = (int)sourceNumber.Type;
                }
                else
                {
                    destination.PhoneNumbers.Remove(phoneNumber);
                }
            }
        }

        private void AddNewPhoneNumbers(UpdatePersonCommand source, Person destination)
        {
            var newNumbers = source.PhoneNumbers
                .Where(x => x.Id == 0)
                .Select(x => new PhoneNumber
                {
                    Number = x.Value,
                    PhoneNumberTypeId = (int)x.Type
                }).ToList();

            newNumbers.ForEach(x => destination.PhoneNumbers.Add(x));
        }
    }
}
