using Mapster;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Services;
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
        public ActionResult RenderReservationForm(object resultModel)
        {
            return View(PARTIAL_VIEW_FOLDER + "_Reservation.cshtml", resultModel);
        }

        public ActionResult RenderEconomyForm()
        {
            return View(PARTIAL_VIEW_FOLDER + "_Economy.cshtml");
        }

        public ActionResult RenderCheckoutForm()
        {
            return View(PARTIAL_VIEW_FOLDER + "_Checkout.cshtml");
        }
        public ActionResult RenderSummaryForm()
        {
            return View(PARTIAL_VIEW_FOLDER + "_Summary.cshtml");
        }

        [HttpPost]
        public string InsertReservation(string capacity, string address, string products)
        {
            JObject capacitiesObj = JObject.Parse(capacity);
            JObject addressObj = JObject.Parse(address);
            var productsDto = JsonConvert.DeserializeObject<List<ProductsDto>>(products);
            var productsModel = productsDto.Adapt<List<ProductsModel>>();
            ReservationRequestModel reservationRequestModel = new ReservationRequestModel();
            reservationRequestModel.resNo = 0;
            reservationRequestModel.resCorpNo = 0;

            foreach (var item in productsModel)
            {
                item.currency = "TRY";
                item.salesType = "1";
            }
            reservationRequestModel.pickupDate = capacitiesObj["pickupDate"].ToString();
            reservationRequestModel.returnDate = capacitiesObj["returnDate"].ToString();
            reservationRequestModel.pickupLocNo = long.Parse(capacitiesObj["pickupLocNo"].ToString());
            reservationRequestModel.returnLocNo = long.Parse(capacitiesObj["returnLocNo"].ToString());
            reservationRequestModel.classNo = long.Parse(capacitiesObj["classNo"].ToString());
            reservationRequestModel.typeNo = long.Parse(capacitiesObj["vehicleTypes"][0]["typeNo"].ToString());
            reservationRequestModel.rentalDays = int.Parse(capacitiesObj["rentalDays"].ToString());
            reservationRequestModel.extraHours = int.Parse(capacitiesObj["extraHours"].ToString());
            reservationRequestModel.onewayPrice = double.Parse(capacitiesObj["onewayPrice"].ToString());
            reservationRequestModel.onewayCurrency = "TRY";// capacitiesObj["onewayCurrency"].ToString();
            reservationRequestModel.totalRentalPrice = double.Parse(capacitiesObj["tariffs"][0]["totalRentalPrice"].ToString());
            reservationRequestModel.rentalPriceCurrency = "TRY";//capacitiesObj["onewayCurrency"].ToString();
            reservationRequestModel.typeNo = long.Parse(capacitiesObj["vehicleTypes"][0]["typeNo"].ToString());
            reservationRequestModel.addresses = new List<AddressModel>();
            long cityy = 0;
            reservationRequestModel.addresses.Add(new AddressModel
            {
                idNo = "34290",
                addressNo = long.Parse(addressObj["addressNo"].ToString()),
                addressCorpNo = long.Parse(addressObj["addressCorpNo"].ToString()),
                addressType = addressObj["addressType"].ToString(),
                billingAddress = bool.Parse(addressObj["billingAddress"].ToString()),
                shippingAddress = bool.Parse(addressObj["shippinAddress"].ToString()),
                name = addressObj["name"].ToString(),
                lastname = addressObj["lastname"].ToString(),
                corpName = addressObj["corpName"].ToString(),
                corpStyle = addressObj["corpStyle"].ToString(),
                address = addressObj["address"].ToString(),
                districtName = addressObj["districtName"].ToString(),
                cityNo = long.TryParse(addressObj["cityNo"].ToString(), out cityy) == false ? 0 : long.Parse(addressObj["cityNo"].ToString()),
                countryCode = addressObj["countryCode"].ToString(),
                phone11 = addressObj["phone11"].ToString(),
                phone22 = addressObj["phone22"].ToString(),
                mobPhone1 = addressObj["mobPhone1"].ToString(),
                mobPhone2 = addressObj["mobPhone2"].ToString(),
                phoneHome = addressObj["phoneHome"].ToString(),
                email = addressObj["email"].ToString()

            });
            reservationRequestModel.products = productsModel;
            reservationRequestModel.referenceNo = string.Empty;
            reservationRequestModel.voucherNo = string.Empty;
            reservationRequestModel.fullCredit = false;
            reservationRequestModel.deliveryPlace = capacitiesObj["pickupLocName"].ToString();
            reservationRequestModel.dropPlace = capacitiesObj["returnLocName"].ToString();
            reservationRequestModel.pickupFromAirport = false;
            reservationRequestModel.returnToAirport = false;
            reservationRequestModel.resSourceNo = 187;//“ReservationSources” metodundan dönen değerlerden biri 188 dönmekte sadece
            reservationRequestModel.paymentTypeNo = 353;//Nakit
            reservationRequestModel.tariffNo = 380; //Şimdi öde
            reservationRequestModel.campaignNo = long.Parse(capacitiesObj["campaignNo"].ToString());
            reservationRequestModel.note = string.Empty;
            reservationRequestModel.webSource = "TR";
            reservationRequestModel.requireConfirmation = true;//Araç kiralama firmasından ayrıca rezervasyon onayı istenecekse “true
            reservationRequestModel.brokerUserNo = 0;
            reservationRequestModel.promotionCode = string.Empty;
            reservationRequestModel.resStatus = string.Empty;

            OperationResultModel result = _prorentService.InsertReservation(reservationRequestModel);

            if (result.success)
            {
                SendMailOnReservationInsertRequestModel mailModel = new SendMailOnReservationInsertRequestModel();
                mailModel.resNo = result.resNo;
                mailModel.toCustomer = true;
                mailModel.toVendor = true;
                mailModel.resCorpNo = result.resCorpNo;

                SendMailOnReservationInsertRequestDto mailResultModel = _prorentService.SendMailOnReservationInsert(mailModel).Adapt<SendMailOnReservationInsertRequestDto>();
            }
            return JsonConvert.SerializeObject(result.resNo);

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
        public string GetCountries()
        {
            CountriesResponseDto[] resultModel = _prorentService.GetCountries("TR").Adapt<CountriesResponseDto[]>();
            return JsonConvert.SerializeObject(resultModel);
        }
        [HttpPost]
        public string GetCities(string countryCode)
        {
            CitiesResponseDto[] resultModel = _prorentService.GetCities(countryCode).Adapt<CitiesResponseDto[]>();
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
        [HttpGet]
        public ActionResult Reservation(string obj)
        {
            var reservationDto = JsonConvert.DeserializeObject<CapacitiesRequestDto>(obj);
            var model = reservationDto.Adapt<CapacitiesRequestModel>();
            CapacitiesResponseDto[] resultModel = _prorentService.GetCapacities(model).Adapt<CapacitiesResponseDto[]>();
            if (model.orderby == "priceasc")
                resultModel = resultModel.OrderBy(x => x.onewayPrice).ToArray();
            else if (reservationDto.orderby == "pricedesc")
                resultModel = resultModel.OrderByDescending(x => x.onewayPrice).ToArray();
            return View(resultModel);
        }
        [HttpPost]
        public string GetCapacities(CapacitiesRequestDto dto)
        {
            var model = dto.Adapt<CapacitiesRequestModel>();
            CapacitiesResponseDto[] resultModel = _prorentService.GetCapacities(model).Adapt<CapacitiesResponseDto[]>();
            return JsonConvert.SerializeObject(resultModel);
        }
        [HttpGet]
        public ActionResult Economy(string economyObj, string capacity)
        {
            var economyDto = JsonConvert.DeserializeObject<ExtraProductsRequestDto>(economyObj);
            var model = economyDto.Adapt<ExtraProductsRequestModel>();
            ExtraProductsResponseDto[] resultModel = _prorentService.GetExtraProducts(model).Adapt<ExtraProductsResponseDto[]>();
            var capacityModel = JsonConvert.DeserializeObject<CapacitiesResponseDto>(capacity);
            capacityModel.classNo = economyDto.classNo;
            ViewBag.SelectedVehicle = capacityModel;
            return View(resultModel);
        }
        [HttpGet]
        public ActionResult Summary(string capacity, string economy, string reservationOwner,string orderNumber)
        {

            var reservationOwnerDto = JsonConvert.DeserializeObject<AddressDto>(reservationOwner);
            var reservationOwnerModel = reservationOwnerDto.Adapt<AddressModel>();
            var economyDto = JsonConvert.DeserializeObject<ProductsDto[]>(economy);
            ViewBag.ReservationOwner = reservationOwnerModel;
            ViewBag.Product = economyDto;
            ViewBag.ProductName = string.Join(",", economyDto.Select(s => s.productName).ToList());
            var capacityModel = JsonConvert.DeserializeObject<CapacitiesResponseDto>(capacity);
            ViewBag.SelectedVehicle = capacityModel;
            ViewBag.OrderNumber = JsonConvert.DeserializeObject<string>(orderNumber);
            return View();
        }
        [HttpGet]
        public ActionResult Checkout(string capacity, string economy)
        {
            var economyDto = JsonConvert.DeserializeObject<ProductsDto[]>(economy);
            var capacityDto = JsonConvert.DeserializeObject<CapacitiesResponseDto>(capacity);
            ViewBag.Capacity = capacityDto;
            ViewBag.Economy = economyDto;
            ViewBag.TotalPrice = economyDto.Sum(s => s.totalPrice) + capacityDto.tariffs[0].totalRentalPrice;
            ViewBag.ProductName = string.Join(",", economyDto.Select(s => s.productName).ToList());
            return View();
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
