using Diarna.Data.Domain;
using Diarna.DTOs.TenderShare2;
using AutoMapper;
namespace Diarna.Profiles
{
    public class TenderShare2Profile : Profile
    {
        public TenderShare2Profile()
        {
            CreateMap<TblTenderShare, ReadTenderShare2Dto>()
                .ForMember(dest => dest.TenderName, opt => opt.MapFrom(src => src.Tender.Name))
                .ForMember(dest => dest.ShareName, opt => opt.MapFrom(src => src.Shares.Name));
            CreateMap<CreateTenderShare2Dto, TblTenderShare>();
        }
    }
}
