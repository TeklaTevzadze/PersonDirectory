using PersonDirectory.Domain.Common;
using PersonDirectory.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Domain.Entities
{
    public class Person : BaseEntity<int>, ITrackableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int? GenderId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }


        public Gender Gender { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<PersonRelationship> RelatedPersons { get; set; }
    }
}
