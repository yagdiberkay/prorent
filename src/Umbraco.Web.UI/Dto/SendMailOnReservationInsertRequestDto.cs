namespace Umbraco.Web.UI.Dto
{
    public class SendMailOnReservationInsertRequestDto
    {
        public long resNo { get; set; }
        public long resCorpNo { get; set; }
        public bool toVendor { get; set; }
        public bool toCustomer { get; set; }
    }
}
