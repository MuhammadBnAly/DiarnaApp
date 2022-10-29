using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.Building2;

namespace Diarna.Profiles
{
    public class Building2Profile : Profile
    {
        public Building2Profile()
        {
            CreateMap<TblBuilding, ReadBuilding2Dto>()
                .ForMember(dest => dest.VillageName, opt => opt.MapFrom(src => src.Village.Name));
            CreateMap<CreateBuilding2Dto, TblBuilding>();
        }
    }
}
