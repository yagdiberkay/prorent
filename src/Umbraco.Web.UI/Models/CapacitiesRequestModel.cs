namespace Umbraco.Web.UI.Models
{

    public class CapacitiesRequestModel
    {
        public long pickupLocNo { get; set; }
        public string pickupDate { get; set; }
        public long returnLocNo { get; set; }
        public string returnDate { get; set; }
        public long classNos { get; set; }
        public long tariffNos { get; set; }
        public long campaignNo { get; set; }
        public string language { get; set; }
    }
}
