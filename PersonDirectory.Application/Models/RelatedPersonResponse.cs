using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Models
{
    public class RelatedPersonResponse : PersonBaseResponse
    {
        public int RelatedPersonId { get; set; }
        public string RelationshipType { get; set; }
    }
}
