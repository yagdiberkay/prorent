namespace Umbraco.Web.UI.Models
{
    public class CountriesResponseModel
    {
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string phoneCode { get; set; }
        public CitiesResponseModel[] cities { get; set; }
    }
}
