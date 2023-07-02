using API.Dtos.Item;
using API.Models;
using AutoMapper;

namespace API
{
	public class AutoMapperProfile : Profile
	{
        public AutoMapperProfile()
        {
            CreateMap<AddItemDto, Item>();
            CreateMap<Item, GetItemDto>();
        }
    }
}
