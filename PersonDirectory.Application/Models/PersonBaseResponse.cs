using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Models
{
    public class PersonBaseResponse : PersonBase
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public List<PhoneNumberResponseModel> PhoneNumbers { get; set; }
    }
    public class PhoneNumberResponseModel
    {
        public string Type { get; set; }
        public string Number { get; set; }
    }
}
