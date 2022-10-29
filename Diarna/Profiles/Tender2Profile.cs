using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.Tender2;

namespace Diarna.Profiles
{
    public class Tender2Profile : Profile
    {
        public Tender2Profile()
        {
            CreateMap<TblTender, ReadTender2Dto>();
            CreateMap<CreateTender2Dto, TblTender>();
        }
    }
}
