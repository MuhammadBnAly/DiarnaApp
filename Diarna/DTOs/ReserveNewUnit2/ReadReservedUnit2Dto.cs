using System;
using System.ComponentModel.DataAnnotations;

namespace Diarna.DTOs.ReserveNewUnit2
{
    public class ReadReservedUnit2Dto
    {
        //public int UnitId { get; set; }
        [Display(Name = "اسم الوحده")]
        public string UnitName { get; set; }
        //public int? RentUserId { get; set; }
        [Display(Name = "اسم المستأجر")]
        public string RentUserName { get; set; }
        [Display(Name = "رقم التلفون")]
        public string RentUserMobile { get; set; }
        //public int DateId { get; set; }
        [Display(Name = "تاريخ البداية")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاريخ النهاية")]
        public DateTime EndDate { get; set; }
        [Display(Name = "المقدم")]
        public decimal? DepositValue { get; set; }
        [Display(Name = "التأمين")]
        public decimal? InsuranceValue { get; set; }
        [Display(Name = "المبلغ الكلى")]
        public decimal? TotalValue { get; set; }


    }
}
