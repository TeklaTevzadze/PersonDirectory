using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Application.Extensions;
using PersonDirectory.Application.Features.Persons.Queries.Common;
using PersonDirectory.Application.Models;
using PersonDirectory.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.Persons.Queries.GetPersonsQuery
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, PagedData<PersonResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetPersonsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedData<PersonResponse>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Persons.Include(x => x.Gender).Include(x => x.PhoneNumbers).ThenInclude(x => x.PhoneNumberType)
                .Include(x => x.RelatedPersons).ThenInclude(x => x.RelatedPerson).ThenInclude(x => x.PhoneNumbers).ThenInclude(x => x.PhoneNumberType)
                .Include(x => x.RelatedPersons).ThenInclude(x => x.RelationshipType).Include(x => x.RelatedPersons).ThenInclude(x => x.RelatedPerson).ThenInclude(x => x.Gender);

            var filterInfo = GetFilterInfo(request.SearchText, request.Details);

            var query = data.Where(o => o.DateDeleted == null &&
               ((!filterInfo.IsDetailedSearch && (!filterInfo.FastSearchHasValue ||
                   o.FirstName.Contains(request.SearchText) || o.LastName.Contains(request.SearchText) || o.IdentityNumber.Contains(request.SearchText))) ||
                   (filterInfo.IsDetailedSearch &&
                   (!filterInfo.FirstNameHasValue || o.FirstName.Contains(request.Details.FirstName)) &&
                   (!filterInfo.LastNameHasValue || o.LastName.Contains(request.Details.LastName)) &&
                   (!filterInfo.GenderHasValue || o.GenderId == request.Details.GenderId) &&
                   (!filterInfo.IdentityNumberHasValue || o.IdentityNumber.Contains(request.Details.IdentityNumber)) &&
                   (!filterInfo.BirthDateHasValue || o.BirthDate == request.Details.BirthDate) &&
                   (!filterInfo.PhoneNumberHasValue || o.PhoneNumbers.Any(i => i.Number.Contains(request.Details.PhoneNumber))))
               ));

            var result = _mapper.Map<ICollection<PersonResponse>>(query);

            var response = await result.ToPagedData(request.PageNumber, request.PageSize, cancellationToken);

            return response;
        }

        #region Private
        private FilterInfo GetFilterInfo(string searchText, SearchDetails details)
        {
            var isDetailedSearch = details != null;
            var result = new FilterInfo
            {
                IsDetailedSearch = isDetailedSearch,
                FastSearchHasValue = !isDetailedSearch && !string.IsNullOrEmpty(searchText),
                FirstNameHasValue = isDetailedSearch && !string.IsNullOrEmpty(details.FirstName),
                LastNameHasValue = isDetailedSearch && !string.IsNullOrEmpty(details.LastName),
                GenderHasValue = isDetailedSearch && details.GenderId.HasValue,
                IdentityNumberHasValue = isDetailedSearch && !string.IsNullOrEmpty(details.IdentityNumber),
                BirthDateHasValue = isDetailedSearch && details.BirthDate.HasValue,
                PhoneNumberHasValue = isDetailedSearch && !string.IsNullOrEmpty(details.PhoneNumber)
            };
            return result;
        }
        #endregion
    }
}
