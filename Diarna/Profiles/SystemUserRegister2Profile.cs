using Diarna.Data.Domain;
using Diarna.DTOs.SystemUserRegister;
using AutoMapper;
namespace Diarna.Profiles
{
    public class SystemUserRegister2Profile : Profile
    {
        public SystemUserRegister2Profile()
        {
            CreateMap<TblSystemUser, ReadSystemUser2Dto>();
            CreateMap<ReadSystemUser2Dto, TblSystemUser>();

            CreateMap<CreateSystemUser2Dto, TblSystemUser>();
        }
    }
}
