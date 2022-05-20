namespace Umbraco.Web.UI.Models
{
    public class ExtraProductsRequestModel
    {
        public int rentalDays { get; set; }
        public long[] tariffNos { get; set; }
        public long campaignNo { get; set; }
        public long classNo { get; set; }
        public string language { get; set; }
    }
}
