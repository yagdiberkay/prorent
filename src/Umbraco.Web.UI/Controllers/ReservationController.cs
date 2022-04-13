using AutoMapper;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.UI.Dto;
using Umbraco.Web.UI.Models;
using Umbraco.Web.UI.Services;

namespace Umbraco.Web.UI.Controllers
{
    public class ReservationController : SurfaceController
    {
        IProrentService _prorentService;
        Umbraco.Web.UI.Mapping.Mapping _mapping;
        private IMapper _mapper;
        public ReservationController(IProrentService prorentService, IMapper mapper)
        {
            _prorentService = prorentService;
            _mapper = mapper;
        }
        public ActionResult RemderForm()
        {

            return View("Reservation.cshtml");
        }

        public ActionResult InsertReservation(ReservationDto dto)
        {
            if (ModelState.IsValid)
            {
                _mapper = _mapping.MappingConfig().CreateMapper();
                var data = _mapper.Map<ReservationDto, ReservationModel>(dto);

                OperationResultModel resultModel = _prorentService.InsertReservation(data);
                SendEmail(dto);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        public void SendEmail(ReservationDto dto)
        {
            MailMessage mailMessage = new MailMessage(dto.addresses.FirstOrDefault().email, "mailadresigelecek");
            mailMessage.Subject = string.Format("Talebiniz {0} rezervasyon numarası ile alınmıştır", dto.resNo);
            mailMessage.Body = string.Empty;
            SmtpClient client = new SmtpClient("127.0.0.0", 25);
            client.Send(mailMessage);
        }
    }
}
