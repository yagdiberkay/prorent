using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.UI.Dto;

namespace Umbraco.Web.UI.Controllers
{
    public class ReservationController : SurfaceController
    {

        public ActionResult RemderForm()
        {

            return View("Reservation.cshtml");
        }

        public ActionResult InsertReservation(ReservationDto dto)
        {
            if (ModelState.IsValid)
            {
                SendEmail(dto);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        public void SendEmail(ReservationDto dto)
        {
            MailMessage mailMessage = new MailMessage(dto.addresses.FirstOrDefault().email,"mailadresigelecek");
            mailMessage.Subject = string.Format("Talebiniz {0} rezervasyon numarası ile alınmıştır", dto.resNo);
            mailMessage.Body = string.Empty;
            SmtpClient client = new SmtpClient("127.0.0.0", 25);
            client.Send(mailMessage);
        }
    }
}
