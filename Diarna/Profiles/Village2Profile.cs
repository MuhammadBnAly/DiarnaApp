using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.Village2;

namespace Diarna.Profiles
{
    public class Village2Profile : Profile
    {
        public Village2Profile()
        {
            CreateMap<TblVillage, ReadVillage2Dto>();
            CreateMap<CreateVillage2Dto, TblVillage>();
            //CreateMap<ReadVillage2Dto,TblVillage>();
        }
    }
}
