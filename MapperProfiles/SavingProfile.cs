using AutoMapper;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Models;

namespace HouseholdManagerApi.MapperProfiles
{
    public class SavingProfile : Profile
    {
        public SavingProfile()
        {
            CreateMap<SavingDTO, Saving>()
                .ForMember(s => s.TagId, opt => opt.MapFrom(src => src.Tag))
                .ForMember(s => s.Tag, opt => opt.Ignore());
            CreateMap<Saving, SavingDTO>()
                .ForMember(s => s.Tag, opt => opt.MapFrom(src => src.TagId))
                .ForSourceMember(d => d.Tag, opt => opt.DoNotValidate());
        }
    }
}
