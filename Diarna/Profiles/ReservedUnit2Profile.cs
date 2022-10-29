using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.ReservedUnit2;

namespace Diarna.Profiles
{
    public class ReservedUnit2Profile : Profile
    {
        public ReservedUnit2Profile()
        {
            CreateMap<TblReservation, ReadReservedUnit2Dto>()
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Unit.Building.Name))
                .ForMember(dest => dest.VillageName, opt => opt.MapFrom(src => src.Unit.Building.Village.Name))
                .ForMember(dest => dest.ReservedStartDate, opt => opt.MapFrom(src => src.Date.StartDate))
                .ForMember(dest => dest.ReservedEndDate, opt => opt.MapFrom(src => src.Date.EndDate))
                .ForMember(dest => dest.RentUserName, opt => opt.MapFrom(src => src.RentUser.Name))
                .ForMember(dest => dest.RentUserMobile, opt => opt.MapFrom(src => src.RentUser.Mobile));
            CreateMap<ReadReservedUnit2Dto, TblReservation>();
            CreateMap<CreateReservedUnit2Dto, TblReservation>();
        }
    }
}
