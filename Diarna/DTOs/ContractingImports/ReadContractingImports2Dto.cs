﻿using System;
namespace Diarna.DTOs.ContractingImports
{
    public class ReadContractingImports2Dto
    {
        public int Id { get; set; }
        //public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public double? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
        //public int? TenderId { get; set; }
        public string TenderName { get; set; }
    }
}
