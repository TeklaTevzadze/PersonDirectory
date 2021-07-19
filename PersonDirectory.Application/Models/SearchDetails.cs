using System;

namespace PersonDirectory.Application.Models
{
    public class SearchDetails : PersonBase
    {
        public int? GenderId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
