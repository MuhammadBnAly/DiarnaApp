namespace Diarna.DTOs.Unit2
{
    public class CreateUnit2Dto
    {
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int? BuildingId { get; set; }

        //public string BuildingName { get; set; }
        public bool? SystemOwned { get; set; }
        public bool? IsValid { get; set; }
        public decimal? MinDepositValue { get; set; }
        public decimal? MinInsuranceValue { get; set; }
    }
}
