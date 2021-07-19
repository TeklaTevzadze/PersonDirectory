using PersonDirectory.Application.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Models
{
    public class PersonBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
    }
}
