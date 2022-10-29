using System;
namespace Diarna.DTOs.RentedUnit2
{
    public class ReadAllRentedUnit2Dto
    {
        //public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string UnitVillage { get; set; }
        //public int DateId { get; set; }
        public DateTime? RentStartDate { get; set; }
        public DateTime? RentEndDate { get; set; }
        public decimal? TotalValue { get; set; }

        //public int? RentUserId { get; set; }
        public string RentUserName { get; set; }
        public string RentUserMobile { get; set; }

        //public decimal? DepositValue { get; set; }
        //public decimal? InsuranceValue { get; set; }
        //public byte? ConfirmReservation { get; set; }
    }
}
