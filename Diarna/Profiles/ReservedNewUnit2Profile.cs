using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.ReserveNewUnit2;


namespace Diarna.Profiles
{
    public class ReservedNewUnit2Profile : Profile
    {
        public ReservedNewUnit2Profile()
        {
            CreateMap<TblReservation, ReadReservedUnitSimple2Dto>()
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Date.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Date.EndDate));

            CreateMap<TblReservation, ReadReservedUnit2Dto>()
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.RentUserName, opt => opt.MapFrom(src => src.RentUser.Name))
                .ForMember(dest => dest.RentUserMobile, opt => opt.MapFrom(src => src.RentUser.Mobile))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Date.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Date.EndDate));

            CreateMap<TblReservation, ReadOnlyUnit2Dto>()
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name));

            CreateMap<ReadReservedUnit2Dto, TblReservation>();
            CreateMap<ReadOnlyUnit2Dto, TblReservation>();
            CreateMap<ReadReservedUnitSimple2Dto, TblReservation>();

        }
    }
}
