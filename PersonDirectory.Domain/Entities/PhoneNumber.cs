using PersonDirectory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Domain.Entities
{
    public class PhoneNumber : BaseEntity<int>
    {
        public int PersonId { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public string Number { get; set; }

        public Person Person { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
