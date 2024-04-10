using AutoMapper;
using HouseholdManagerApi.DTOs;
using HouseholdManagerApi.Models;

namespace HouseholdManagerApi.MapperProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDTO, Item>()
                .ForMember(s => s.TagId, opt => opt.MapFrom(src => src.Tag))
                .ForMember(s => s.Tag, opt => opt.Ignore());
            CreateMap<Item, ItemDTO>()
                .ForMember(s => s.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate != null ? src.ExpirationDate.Value.ToString() + "Z" : null))
                .ForMember(s => s.Tag, opt => opt.MapFrom(src => src.TagId))
                .ForSourceMember(d => d.Tag, opt => opt.DoNotValidate());
        }
    }
}
