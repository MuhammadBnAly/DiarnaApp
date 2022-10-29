using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Reservation2;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class Reservation2Profile : Profile
    {
        public Reservation2Profile()
        {
            CreateMap<TblReservation, ReadReservation2Dto>()
                .ForMember(dest => dest.RentUserName, opt => opt.MapFrom(src => src.RentUser.Name))
                .ForMember(dest => dest.RentUserMobile, opt => opt.MapFrom(src => src.RentUser.Mobile))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Date.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Date.EndDate));

            CreateMap<CreateReservation2Dto, TblReservation>();

        }
    }
}
