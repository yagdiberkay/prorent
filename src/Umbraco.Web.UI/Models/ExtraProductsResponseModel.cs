namespace Umbraco.Web.UI.Models
{
    public class ExtraProductsResponseModel
    {
        public long productNo { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public long tariffNo { get; set; }
        public string salesType { get; set; }
        public double unitPrice { get; set; }
        public double totalPrice { get; set; }
        public bool included { get; set; }
        public bool selected { get; set; }
        public bool incremental { get; set; }
        public bool calculateTax { get; set; }
        public bool insurance { get; set; }
        public string order { get; set; }
        public string prodImg { get; set; }
        public string currency { get; set; }
    }
}
