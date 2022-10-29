
using System;

namespace Diarna.DTOs.Tender2
{
    public class CreateTender2Dto
    {
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public decimal? TatalPrice { get; set; }
        public string Image { get; set; }
    }
}
