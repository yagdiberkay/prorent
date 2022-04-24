namespace Umbraco.Web.UI.Models
{
    public class SendMailOnReservationInsertResponseModel
    {
        public long resNo { get; set; }
        public long resCorpNo { get; set; }
        public bool successVendor { get; set; }
        public bool successCustomer { get; set; }
        public string emailsVendor { get; set; }
        public string emailsCustomer { get; set; }
        public string message { get; set; }
    }
}
