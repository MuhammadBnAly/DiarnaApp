using Diarna.Data.Domain;
using Diarna.DTOs.RentUser2;
using AutoMapper;
namespace Diarna.Profiles
{
    public class RentUser2Profile : Profile
    {
        public RentUser2Profile()
        {
            CreateMap<TblRentUser, ReadRentUser2Dto>();
            CreateMap<CreateRentUser2Dto, TblRentUser>();

            CreateMap<ReadRentUser2Dto, TblRentUser>();
        }
    }
}
