using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.ItemType2;

namespace Diarna.Profiles
{
    public class ItemType2Profile : Profile
    {
        public ItemType2Profile()
        {
            CreateMap<TblItemType, ReatItemType2Dto>();
            CreateMap<CreateItemType2Dto, TblItemType>();
        }
    }
}
