namespace Umbraco.Web.UI.Models
{
    public class OperationResultModel
    {
        public bool success { get; set; }
        public long resNo { get; set; }
        public long resCorpNo { get; set; }
        public long resAdNo { get; set; }
        public string message { get; set; }
        public string resStatus { get; set; }
    }
}
