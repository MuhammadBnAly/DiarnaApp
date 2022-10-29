using System;
namespace Diarna.DTOs.ContractingImports
{
    public class CreateContractingImport2Dto
    {
        public int? ItemId { get; set; }
        public double? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
        public int? TenderId { get; set; }
    }
}
