using Diarna.DTOs.UserShare2;
using Diarna.Data.Domain;
using AutoMapper;

namespace Diarna.Profiles
{
    public class UserShare2Profile : Profile
    {
        public UserShare2Profile()
        {
            CreateMap<TblUserShare, ReadUserShare2Dto>();
            CreateMap<CreateUserShare2Dto, TblUserShare>();

        }
    }
}
