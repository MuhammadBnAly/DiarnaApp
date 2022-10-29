using System;

namespace Diarna.DTOs.RentExpense
{
    public class ReadRentExpenseDto
    {
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public decimal? ItemValue { get; set; }

    }
}
