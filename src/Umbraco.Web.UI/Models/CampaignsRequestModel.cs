namespace Umbraco.Web.UI.Models
{
    public class CampaignsRequestModel
    {
        public long pickupLocNo { get; set; }
        public string pickupDate { get; set; }
        public long returnLocNo { get; set; }
        public string returnDate { get; set; }
        public long tariffNo { get; set; }
    }
}
