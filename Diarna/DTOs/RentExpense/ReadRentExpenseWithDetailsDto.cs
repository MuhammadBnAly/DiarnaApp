
using System;

namespace Diarna.DTOs.RentExpense
{
    public class ReadRentExpenseWithDetailsDto
    {
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public decimal? ItemValue { get; set; }

        //public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string ItemName { get; set; }

    }
}
