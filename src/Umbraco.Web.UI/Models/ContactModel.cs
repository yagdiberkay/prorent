using System.ComponentModel.DataAnnotations;

namespace Umbraco.Web.UI.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı giriniz.")]
        [Display(Name = "Adınız (gerekli)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen eposta adresi giriniz.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Lütfen mesaj giriniz.")]
        public string Message { get; set; }
    }
}
