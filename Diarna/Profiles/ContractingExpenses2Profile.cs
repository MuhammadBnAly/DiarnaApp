using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.ContractingExpenses;


namespace Diarna.Profiles
{
    public class ContractingExpenses2Profile : Profile
    {
        public ContractingExpenses2Profile()
        {
            CreateMap<TblContractingExpnse, ReadContractingExpensesDto>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.TenderName, opt => opt.MapFrom(src => src.Tender.Name));

            CreateMap<ReadContractingExpensesDto, TblContractingExpnse>();

            CreateMap<CreateContractingExpensesDto, TblContractingExpnse>();
//                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.ItemName))
//                .ForMember(dest => dest.Tender.Name, opt => opt.MapFrom(src => src.TenderName));

        }
    }
}
