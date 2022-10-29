using System;
namespace Diarna.DTOs.ReservedUnit2
{
    public class ReadReservedUnit2Dto
    {

        //public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public string VillageName { get; set; }
        //
        //public int DateId { get; set; }
        public DateTime ReservedStartDate { get; set; }
        public DateTime ReservedEndDate { get; set; }
        //
        public decimal? TotalValue { get; set; }
        //
        //public int RentUserId { get; set; }
        public string RentUserName { get; set; }
        public string RentUserMobile { get; set; }

    }
}
