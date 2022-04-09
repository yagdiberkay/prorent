namespace Umbraco.Web.UI.Models
{
    public class AddressModel
    {
        public long addressNo { get; set; }
        public long addressCorpNo { get; set; }
        public string addressType { get; set; }
        public bool billingAddress { get; set; }
        public bool shippingAddress { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string corpName { get; set; }
        public string corpStyle { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public string roomNo { get; set; }
        public string buildingName { get; set; }
        public string buildingNo { get; set; }
        public string districtName { get; set; }
        public long cityNo { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string postalZone { get; set; }
        public string taxOffice { get; set; }
        public string taxId { get; set; }
        public string phone11 { get; set; }
        public string phone22 { get; set; }
        public string fax { get; set; }
        public string mobPhone1 { get; set; }
        public string mobPhone2 { get; set; }
        public string phoneHome { get; set; }
        public string email { get; set; }
        public string idType { get; set; }
        public string idNo { get; set; }
        public string idIssuePlace { get; set; }
        public string idIssueDate { get; set; }
        public string birthPlace { get; set; }
        public string birthDate { get; set; }
        public string licenseNo { get; set; }
        public string licenseIssuePlace { get; set; }
        public string licenseIssueDate { get; set; }
        public bool permitPersonalDataStorage { get; set; }
        public bool permitCommunication { get; set; }

    }
}
