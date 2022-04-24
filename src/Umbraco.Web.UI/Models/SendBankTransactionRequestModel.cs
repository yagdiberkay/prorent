namespace Umbraco.Web.UI.Models
{
    public class SendBankTransactionRequestModel
    {
        public long resNo { get; set; }
        public long resCorpNo { get; set; }
        public string bankTxNo { get; set; }
        public string bankTxError { get; set; }
        public string orderId { get; set; }
        public string vposIntegrator { get; set; }
        public string cardNo { get; set; }
        public string cardCvv { get; set; }
        public string cardHolder { get; set; }
        public int cardExpiryYear { get; set; }
        public int cardExpiryMonth { get; set; }
        public double paidAmount { get; set; }
        public string currency { get; set; }
        public double exchangeRate { get; set; }
        public double paidAmountLocalCurrency { get; set; }
        public long paymentTypeNo { get; set; }

    }
}
