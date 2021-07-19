using PersonDirectory.Application.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Models
{
    public class PersonRequest : PersonBase
    {
        public DateTime BirthDate { get; set; }
        public GenderEnum? Gender { get; set; }
        public List<TypeData<PhoneNumberTypeEnum>> PhoneNumbers { get; set; }
    }
}
