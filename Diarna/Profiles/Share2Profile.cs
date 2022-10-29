using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.Share2;


namespace Diarna.Profiles
{
    public class Share2Profile : Profile
    {
        public Share2Profile()
        {
            CreateMap<TblShare, ReadShare2Dto>();
            CreateMap<TblShare, ReadShareDetails2Dto>()
                .ForMember(dest => dest.UserShareName, opt => opt.MapFrom(src => src.UserShares.Name));
            CreateMap<CreateShare2Dto, TblShare>();

            CreateMap<ReadShare2Dto, TblShare>();
            CreateMap<ReadShareDetails2Dto, TblShare>();

        }
    }
}
