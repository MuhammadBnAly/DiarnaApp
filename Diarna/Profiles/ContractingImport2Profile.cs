using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.ContractingImports;

namespace Diarna.Profiles
{
    public class ContractingImport2Profile : Profile
    {
        public ContractingImport2Profile()
        {
            CreateMap<TblContractingImport, ReadContractingImports2Dto>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.TenderName, opt => opt.MapFrom(src => src.Tender.Name));
            CreateMap<CreateContractingImport2Dto, TblContractingImport>();
        }
    }
}
