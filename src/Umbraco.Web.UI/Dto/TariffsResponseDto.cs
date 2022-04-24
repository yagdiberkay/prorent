namespace Umbraco.Web.UI.Dto
{
    public class TariffsResponseDto
    {
        public long tariffNo { get; set; }
        public string tariffCode { get; set; }
        public string tariffName { get; set; }
        public double totalRentalPrice { get; set; }
        public double hourLimitExceedPrice { get; set; }
        public string rentalPriceCurrency { get; set; }
    }
}
