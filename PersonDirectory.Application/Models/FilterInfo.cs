using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Models
{
    public class FilterInfo
    {
        public bool IsDetailedSearch { get; set; }
        public bool FastSearchHasValue { get; set; }
        public bool FirstNameHasValue { get; set; }
        public bool LastNameHasValue { get; set; }
        public bool GenderHasValue { get; set; }
        public bool IdentityNumberHasValue { get; set; }
        public bool BirthDateHasValue { get; set; }
        public bool PhoneNumberHasValue { get; set; }
    }
}
