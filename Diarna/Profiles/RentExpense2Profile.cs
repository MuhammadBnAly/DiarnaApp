using AutoMapper;
using Diarna.Data.Domain;
using Diarna.DTOs.RentExpense;

namespace Diarna.Profiles
{
    public class RentExpense2Profile :Profile
    {
        public RentExpense2Profile()
        {
            CreateMap<TblRentExpense, ReadRentExpenseDto>();
            CreateMap<TblRentExpense, ReadRentExpenseWithDetailsDto>()
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name));
            CreateMap<CreateRentExpenseWithDetailsDto, TblRentExpense>();
            CreateMap<TblRentExpense, CreateRentExpenseWithDetailsDto>();
            CreateMap<ReadRentExpenseDto, TblRentExpense>();
            CreateMap<ReadRentExpenseWithDetailsDto, TblRentExpense>();
        }
    }
}
