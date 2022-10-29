using System;

namespace Diarna.DTOs.Share2
{
    public class ReadShareDetails2Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte? ShareType { get; set; }
        //public int? UserSharesId { get; set; }
        public string UserShareName { get; set; }
        public decimal? UserCash { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Percent { get; set; }
        public decimal? UserMinProfit { get; set; }



    }
}
