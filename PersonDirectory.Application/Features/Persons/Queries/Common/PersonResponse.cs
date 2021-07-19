using PersonDirectory.Application.Models;
using System.Collections.Generic;

namespace PersonDirectory.Application.Features.Persons.Queries.Common
{
    public class PersonResponse : PersonBaseResponse
    {
        public List<RelatedPersonResponse> RelatedPersons { get; set; }
    }
}
