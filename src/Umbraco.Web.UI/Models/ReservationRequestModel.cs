using System.Collections.Generic;

namespace Umbraco.Web.UI.Models
{
    public class ReservationRequestModel
    {
        public long resNo { get; set; }
        public long resCorpNo { get; set; }
        public string pickupDate { get; set; }
        public string returnDate { get; set; }
        public long pickupLocNo { get; set; }
        public long returnLocNo { get; set; }
        public long classNo { get; set; }
        public long typeNo { get; set; }
        public int rentalDays { get; set; }
        public int extraHours { get; set; }
        public double onewayPrice { get; set; }
        public string onewayCurrency { get; set; }
        public double totalRentalPrice { get; set; }
        public string rentalPriceCurrency { get; set; }
        public List<AddressModel> addresses { get; set; }
        public List<ProductsModel> products { get; set; }
        public FlightModel landingFlight { get; set; }
        public FlightModel takeoffFlight { get; set; }
        public string referenceNo { get; set; }
        public string voucherNo { get; set; }
        public bool fullCredit { get; set; }
        public string deliveryPlace { get; set; }
        public string dropPlace { get; set; }
        public bool pickupFromAirport { get; set; }
        public bool returnToAirport { get; set; }
        public long resSourceNo { get; set; }
        public long paymentTypeNo { get; set; }
        public long tariffNo { get; set; }
        public long campaignNo { get; set; }
        public string note { get; set; }
        public string webSource { get; set; }
        public bool requireConfirmation { get; set; }
        public long brokerUserNo { get; set; }
        public string promotionCode { get; set; }
        public string resStatus { get; set; }
    }
}
