
using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.Unit2;

namespace Diarna.Profiles
{
    public class UpdateUnit2Profile : Profile
    {
        public UpdateUnit2Profile()
        {
            CreateMap<EditUpdateUnit2Dto, TblUnit>();
            CreateMap<TblUnit, ReadUpdateUnit2Dto>();
        }
    }
}
