using System;
namespace Diarna.DTOs.RentedUnit2
{
    public class CreateRentedUnit2Dto
    {
        public int? UnitId { get; set; }
        public string Remarks { get; set; }
        public DateTime? RentStartDate { get; set; }
        public DateTime? RentEndDate { get; set; }
        public decimal? DeliveryPrice { get; set; }


    }
}
