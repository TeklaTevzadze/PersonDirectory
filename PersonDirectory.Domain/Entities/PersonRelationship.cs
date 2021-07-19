using PersonDirectory.Domain.Common;
using PersonDirectory.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Domain.Entities
{
    public class PersonRelationship : BaseEntity<int>, ITrackableEntity
    {
        public int RelatedToPersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public int RelationshipTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Person RelatedToPerson { get; set; }
        public Person RelatedPerson { get; set; }
        public RelationshipType RelationshipType { get; set; }

    }
}
