using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.UI.Dto;
using Umbraco.Web.UI.Models;
using Umbraco.Web.UI.Services;

namespace Umbraco.Web.UI.Controllers
{
    public class ContactController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Reservation/";
        public ActionResult RenderContactForm()
        {
            return View(PARTIAL_VIEW_FOLDER + "_ContactForm.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);

                return RedirectToCurrentUmbracoPage();
            }

            return CurrentUmbracoPage();
        }

        private void SendEmail(ContactModel model)
        {
            string server = "mail.prorent24.com"; //yönetim panelinden
            string from = "info@prorent24.com"; //yönetim panelinden
            string fromPassword = "lc5q6Y_72"; //yönetim panelinden
            string to = "yagdiberkay@gmail.com"; // yönetim panelinden

            MailMessage message = new MailMessage(from, to);
            message.Subject = $"İletişim Maili geldi - {model.Name} - {model.EmailAddress}";
            string body = "<table><tr><td>Email</td><td>{0}</td></tr><tr><td>Ad Soyad</td><td>{1}</td></tr><tr><td>İçerik</td><td>{2}</td></tr></table>";
            message.Body = string.Format(body, model.EmailAddress, model.Name, model.Message);
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(server, 25);
            client.UseDefaultCredentials = false;
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential(from, fromPassword);
            client.Send(message);
        }
    }
}
