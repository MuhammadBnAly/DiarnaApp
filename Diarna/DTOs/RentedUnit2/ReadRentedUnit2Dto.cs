using System;
namespace Diarna.DTOs.RentedUnit2
{
    public class ReadRentedUnit2Dto
    {
        public int Id { get; set; }
        //public int? UnitId { get; set; }
        public string UnitName { get; set; }
        public string Remarks { get; set; }
        public DateTime? RentStartDate { get; set; }
        public DateTime? RentEndDate { get; set; }
        public decimal? DeliveryPrice { get; set; }


    }
}
