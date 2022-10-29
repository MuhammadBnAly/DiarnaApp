using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.RentedUnit2;

namespace Diarna.Profiles
{
    public class RentedUnit2Profile : Profile
    {
        public RentedUnit2Profile()
        {
            CreateMap<TblRentedUnit, ReadRentedUnit2Dto>()
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name));
            CreateMap<CreateRentedUnit2Dto, TblRentedUnit>();
            CreateMap<TblRentedUnit, ReadAllRentedUnit2Dto>()
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(dest => dest.Unit.Name))
                .ForMember(dest => dest.UnitVillage, opt => opt.MapFrom(dest => dest.Unit.Building.Village.Name));
        }
    }
}
