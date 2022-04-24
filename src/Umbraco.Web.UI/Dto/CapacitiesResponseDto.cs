namespace Umbraco.Web.UI.Dto
{
    public class CapacitiesResponseDto
    {
        public bool available { get; set; }
        public CapacitiesCountDto[] capacityCounts { get; set; }
        public long pickupLocNo { get; set; }
        public string pickupLocName { get; set; }
        public long returnLocNo { get; set; }
        public string returnLocName { get; set; }
        public long classNo { get; set; }
        public string classCode { get; set; }
        public string className { get; set; }
        public string classCodeAcriss { get; set; }
        public bool classHasCampaign { get; set; }
        public double provision { get; set; }
        public int creditCardQty { get; set; }
        public string pickupDate { get; set; }
        public string returnDate { get; set; }
        public int rentalDays { get; set; }
        public int extraHours { get; set; }
        public long campaignNo { get; set; }
        public VehicleTypesResponseDto[] vehicleTypes { get; set; }
        public TariffsResponseDto[] tariffs { get; set; }
        public double onewayPrice { get; set; }
        public string onewayCurrency { get; set; }
        public int limitKm { get; set; }
        public bool pickupInsideOfficeHours { get; set; }
        public bool returnInsideOfficeHours { get; set; }
    }
}
