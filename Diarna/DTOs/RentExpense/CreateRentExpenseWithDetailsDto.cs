using System;
using System.ComponentModel.DataAnnotations;
namespace Diarna.DTOs.RentExpense
{
    public class CreateRentExpenseWithDetailsDto
    {
        [Required]
        public int UnitId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public decimal? ItemValue { get; set; }
        
        //[Required]
        //public string UnitName { get; set; }
        //[Required]
        //public string ItemName { get; set; }
    }
}
