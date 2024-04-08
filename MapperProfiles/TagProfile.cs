using AutoMapper;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Models;

namespace HouseholdManagerApi.MapperProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<TagDTO, Tag>()
                .ForMember(s => s.Savings, opt => opt.Ignore());
            CreateMap<Tag, TagDTO>()
                .ForSourceMember(d => d.Savings, opt => opt.DoNotValidate());
        }
    }
}
