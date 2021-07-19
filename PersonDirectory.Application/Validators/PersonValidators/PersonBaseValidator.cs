using FluentValidation;
using PersonDirectory.Application.Models;
using System;
using System.Linq;

namespace PersonDirectory.Application.Validators.PersonValidators
{
    public class PersonBaseValidator : AbstractValidator<PersonRequest>
    {
        public PersonBaseValidator()
        {
            RuleFor(o => o.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50).Matches(@"(^[a-zA-Z]+$)|(^[ა-ჰ]+$)");
            RuleFor(o => o.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50).Matches(@"(^[a-zA-Z]+$)|(^[ა-ჰ]+$)");
            RuleFor(o => o.IdentityNumber).NotNull().NotEmpty().Length(11).Matches(@"^\d{11}$");
            RuleFor(o => o.BirthDate).NotNull().NotEmpty().Must(o => IsAdult(o));

            When(o => o.PhoneNumbers.Any(), () =>
            {
                RuleForEach(o => o.PhoneNumbers).ChildRules(phoneNumber =>
                {
                    phoneNumber.RuleFor(i => i.Value).MinimumLength(4).MaximumLength(50);
                    phoneNumber.RuleFor(i => i.Type).NotNull();
                });
            });
        }

        private static bool IsAdult(DateTime dateOfbirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfbirth.Year;
            if (dateOfbirth.Date > today.AddYears(-age))
                age--;

            return age > 17;
        }
    }
}
