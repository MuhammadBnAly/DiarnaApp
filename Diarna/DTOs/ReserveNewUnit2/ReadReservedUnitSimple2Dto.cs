using System;
using System.ComponentModel.DataAnnotations;
namespace Diarna.DTOs.ReserveNewUnit2
{
    public class ReadReservedUnitSimple2Dto
    {
        [Display(Name = "اسم الوحده")]
        public string UnitName { get; set; }

        [Display(Name = "تاريخ البداية")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاريخ النهاية")]
        public DateTime EndDate { get; set; }

    }
}
