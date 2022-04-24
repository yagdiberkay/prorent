namespace Umbraco.Web.UI.Models
{
    public class SendMailOnReservationInsertRequestModel
    {
        public long resNo { get; set; }
        public long resCorpNo { get; set; }
        public bool toVendor { get; set; }
        public bool toCustomer { get; set; }
    }
}
