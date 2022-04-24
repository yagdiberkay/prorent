namespace Umbraco.Web.UI.Dto
{
    public class CampaignsResponseDto
    {
        public long campaignNo { get; set; }
        public string campaignName { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string pickupLocNos { get; set; }
        public string returnLocNos { get; set; }
        public string tariffNos { get; set; }
        public string classNos { get; set; }
        public int minimumDays { get; set; }
        public int maximumDays { get; set; }
        public double ratio { get; set; }
        public double onewayDiscountPct { get; set; }
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }
        public bool sunday { get; set; }
        public bool mandatory { get; set; }

    }
}
