using System;
namespace Diarna.DTOs.Reservation2
{
    public class CreateReservation2Dto
    {

        public int UnitId { get; set; }
        public int? RentUserId { get; set; }
        //public string RentUserName { get; set; }
        //public string RentUserMobile { get; set; }
        public int DateId { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public decimal? DepositValue { get; set; }
        public decimal? InsuranceValue { get; set; }
        public decimal? TotalValue { get; set; }
        public byte? ConfirmReservation { get; set; }
    }
}
