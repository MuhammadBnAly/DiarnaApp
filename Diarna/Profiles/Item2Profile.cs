using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.Item2;

namespace Diarna.Profiles
{
    public class Item2Profile : Profile
    {
        public Item2Profile()
        {
            CreateMap<TblItem, ReadItem2Dto>()
                .ForMember(dest => dest.ItemTypeName, opt => opt.MapFrom(src => src.Itemtype.Name));
            CreateMap<CreateItem2Dto, TblItem>();
        }
    }
}
