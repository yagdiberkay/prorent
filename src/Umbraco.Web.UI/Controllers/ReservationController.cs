using Mapster;
using Newtonsoft.Json;
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
        public ActionResult RenderReservationDateForm()
        {
            return View(PARTIAL_VIEW_FOLDER + "_ReservationDate.cshtml");
        }
        public ActionResult RenderReservationForm()
        {
            return View(PARTIAL_VIEW_FOLDER + "_Reservation.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertReservation(ReservationRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                var model = dto.Adapt<ReservationRequestModel>();
                OperationResultDto resultModel = _prorentService.InsertReservation(model).Adapt<OperationResultDto>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        [HttpPost]
        public string GetLocations()
        {
            LocationsRequestDto dto = new LocationsRequestDto();
            dto.language = "TR";
            var model = dto.Adapt<LocationsRequestModel>();
            LocationsResponseDto[] resultModel = _prorentService.GetLocations(model).Adapt<LocationsResponseDto[]>();
            return JsonConvert.SerializeObject(resultModel);
        }
        [HttpPost]
        public ActionResult GetCampaigns(CampaignsRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                var model = dto.Adapt<CampaignsRequestModel>();
                CampaignsResponseDto[] resultModel = _prorentService.GetCampaigns(model).Adapt<CampaignsResponseDto[]>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        [HttpPost]
        public ActionResult GetTariffs()
        {
            if (ModelState.IsValid)
            {
                TariffsResponseDto[] resultModel = _prorentService.GetTariffs().Adapt<TariffsResponseDto[]>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        [HttpPost]
        public string GetCapacities(CapacitiesRequestDto dto)
        {
            ViewBag.CapacitiesModel = dto;
            var model = dto.Adapt<CapacitiesRequestModel>();
            CapacitiesResponseDto[] resultModel = _prorentService.GetCapacities(model).Adapt<CapacitiesResponseDto[]>();
            return JsonConvert.SerializeObject(resultModel);
        }
        [HttpPost]
        public ActionResult GetVehicleTypeDetails(VehicleTypeDetailsRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                var model = dto.Adapt<VehicleTypeDetailsRequestModel>();
                VehicleTypeDetailsResponseModel resultModel = _prorentService.GetVehicleTypeDetails(model).Adapt<VehicleTypeDetailsResponseModel>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        [HttpPost]
        public ActionResult GetExtraProducts(ExtraProductsRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                var model = dto.Adapt<ExtraProductsRequestModel>();
                ExtraProductsResponseDto[] resultModel = _prorentService.GetExtraProducts(model).Adapt<ExtraProductsResponseDto[]>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        [HttpPost]
        public ActionResult GetReservationSources()
        {
            if (ModelState.IsValid)
            {
                ReservationSourcesResponseDto[] resultModel = _prorentService.GetReservationSources().Adapt<ReservationSourcesResponseDto[]>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        [HttpPost]
        public ActionResult GetPaymentTypes(string language)
        {
            if (ModelState.IsValid)
            {
                PaymentTypesResponseDto[] resultModel = _prorentService.GetPaymentTypes(language).Adapt<PaymentTypesResponseDto[]>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        [HttpPost]
        public ActionResult SendBankTransaction(SendBankTransactionRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                var model = dto.Adapt<SendBankTransactionRequestModel>();

                OperationResultDto resultModel = _prorentService.SendBankTransaction(model).Adapt<OperationResultDto>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
        [HttpPost]
        public ActionResult SendMailOnReservationInsert(SendMailOnReservationInsertRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                var model = dto.Adapt<SendMailOnReservationInsertRequestModel>();

                SendMailOnReservationInsertRequestDto resultModel = _prorentService.SendMailOnReservationInsert(model).Adapt<SendMailOnReservationInsertRequestDto>();
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
    }
}
