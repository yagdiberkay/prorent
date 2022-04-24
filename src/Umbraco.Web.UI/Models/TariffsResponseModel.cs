namespace Umbraco.Web.UI.Models
{
    public class TariffsResponseModel
    {
        public long tariffNo { get; set; }
        public string tariffCode { get; set; }
        public string tariffName { get; set; }
        public double totalRentalPrice { get; set; }
        public double hourLimitExceedPrice { get; set; }
        public string rentalPriceCurrency { get; set; }
    }
}
