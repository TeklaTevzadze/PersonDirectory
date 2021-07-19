using MediatR;
using PersonDirectory.Application.Features.Persons.Queries.Common;
using PersonDirectory.Application.Features.Persons.Queries.GetPersonQuery;
using PersonDirectory.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Features.Persons.Queries.GetPersonsQuery
{
    public class GetPersonsQuery : IRequest<PagedData<PersonResponse>>
    {
        public string SearchText { get; set; }
        public SearchDetails Details { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
