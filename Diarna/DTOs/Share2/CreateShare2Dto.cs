using System;
using System.ComponentModel.DataAnnotations;
namespace Diarna.DTOs.Share2
{
    public class CreateShare2Dto
    {
        //[Required]
        public string Name { get; set; }
        public byte? ShareType { get; set; }
        //public byte? ShareName { get; set; }
        //[Required]
        //public int? UserSharesId { get; set; }
        //[Required]
        public string UserShareName { get; set; }
        public decimal? UserCash { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Percent { get; set; }
        public decimal? UserMinProfit { get; set; }

    }
}
