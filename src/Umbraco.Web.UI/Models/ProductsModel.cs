namespace Umbraco.Web.UI.Models
{
    public class ProductsModel
    {
        public bool selected { get; set; }
        public long productNo { get; set; }
        public string productName { get; set; }
        public int count { get; set; }
        public string salesType { get; set; }
        public double unitPrice { get; set; }
        public double totalPrice { get; set; }
        public string currency { get; set; }
        public bool included { get; set; }
        public bool incremental { get; set; }
        public bool calculateTax { get; set; }
    }
}
