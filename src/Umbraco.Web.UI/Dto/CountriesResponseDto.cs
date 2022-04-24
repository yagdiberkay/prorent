namespace Umbraco.Web.UI.Dto
{
    public class CountriesResponseDto
    {
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string phoneCode { get; set; }
        public CitiesResponseDto[] cities { get; set; }
    }
}
