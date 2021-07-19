using AutoMapper;
using PersonDirectory.Application.Features.PersonRelationships.Commands.CreatePersonRelationshipCommand;
using PersonDirectory.Application.Features.Persons.Commands.CreatePersonCommand;
using PersonDirectory.Application.Features.Persons.Commands.UpdatePersonCommand;
using PersonDirectory.Application.Features.Persons.Queries.Common;
using PersonDirectory.Application.Mappings.Converters;
using PersonDirectory.Application.Models;
using PersonDirectory.Domain.Entities;

namespace PersonDirectory.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePersonCommand, Person>()
                .ForMember(x => x.Gender, opt => opt.Ignore())
                .ForMember(x => x.PhoneNumbers, opt => opt.Ignore())
                .ForMember(x => x.RelatedPersons, opt => opt.Ignore()).AfterMap<CreatePersonConverter>();
            CreateMap<UpdatePersonCommand, Person>()
                .ForMember(x => x.Gender, opt => opt.Ignore())
                .ForMember(x => x.PhoneNumbers, opt => opt.Ignore())
                .ForMember(x => x.RelatedPersons, opt => opt.Ignore()).AfterMap<UpdatePersonConverter>();
            CreateMap<CreatePersonRelationshipCommand, PersonRelationship>()
                .ForMember(x => x.RelationshipType, opt => opt.Ignore())
                .ForMember(dest => dest.RelationshipTypeId,
                opt => opt.MapFrom(src => (int)src.RelationshipType));
            CreateMap<Person, PersonResponse>()
               .ForMember(x => x.Gender, opt => opt.Ignore())
               .ForMember(x => x.PhoneNumbers, opt => opt.Ignore())
               .ForMember(x => x.RelatedPersons, opt => opt.Ignore()).AfterMap<PersonResponseConverter>();
            CreateMap<PersonRelationship, RelatedPersonResponse>().ConvertUsing<RelatedPersonResponseConverter>();
        }
    }
}
