using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.Unit2;

namespace Diarna.Profiles
{
    public class Unit2Profile : Profile
    {
        public Unit2Profile()
        {
            CreateMap<TblUnit, ReadUnit2Dto>()
                .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Building.Name));
            CreateMap<CreateUnit2Dto, TblUnit>();
        }
    }
}
