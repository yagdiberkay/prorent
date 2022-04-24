using System.Collections.Generic;

namespace Umbraco.Web.UI.Dto
{
    public class LocationsResponseDto
    {
        public long locNo { get; set; }
        public string locCode { get; set; }
        public string locName { get; set; }
        public string locLogoImage { get; set; }
        public string locAddress { get; set; }
        public string locPhone { get; set; }
        public string locFax { get; set; }
        public string locEmail { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string cityName { get; set; }
        public string districtName { get; set; }
        public string locGpsCoordinates { get; set; }
        public string language { get; set; }
        public List<double> openingTimes { get; set; }
        public List<double> closingTimes { get; set; }
    }
}
