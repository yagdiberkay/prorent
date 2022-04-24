using Mapster;
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
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Reservation/";
        public ReservationController(IProrentService prorentService)
        {
            _prorentService = prorentService;
        }
        public ActionResult RenderForm()
        {
            return View(PARTIAL_VIEW_FOLDER + "_Reservation.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitReservation(ReservationDto dto)
        {
            if (ModelState.IsValid)
            {
                var model = dto.Adapt<ReservationModel>();
                OperationResultModel resultModel = _prorentService.InsertReservation(model);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
    }
}
