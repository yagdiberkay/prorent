namespace Umbraco.Web.UI.Models
{
    public class VehicleTypesResponseModel
    {
        public long typeNo { get; set; }
        public string typeFullname { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public long classNo { get; set; }
        public string classCode { get; set; }
        public string className { get; set; }
        public string body { get; set; }
        public string transmission { get; set; }
        public int ccm { get; set; }
        public string engineType { get; set; }
        public int hp { get; set; }
        public string fuelType { get; set; }
        public int fuelCapacity { get; set; }
        public int co2Emission { get; set; }
        public int weight { get; set; }
        public int weightLoad { get; set; }
        public int doors { get; set; }
        public int seats { get; set; }
        public double udc { get; set; }
        public double eudc { get; set; }
        public double nedc { get; set; }
        public int luggageCapacity { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }
        public string img4 { get; set; }
        public string img5 { get; set; }
        public string description { get; set; }
        public string note { get; set; }
        public VehicleFeatureModel[] features { get; set; }
        public bool classOnlineResYn { get; set; }
    }
}
