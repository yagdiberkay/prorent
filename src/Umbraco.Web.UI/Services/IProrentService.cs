using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.UI.Dto;
using Umbraco.Web.UI.Models;

namespace Umbraco.Web.UI.Services
{
    public interface IProrentService
    {

        CitiesResponseModel[] GetCities(string countryCode);
        CountriesResponseModel[] GetCountries(string language);
        CurrenciesResponseModel[] GetCurrencies();
        LocationsResponseModel[] GetLocations(LocationsRequestModel model);
        CampaignsResponseModel[] GetCampaigns(CampaignsRequestModel model);
        TariffsResponseModel[] GetTariffs();
        PaymentTypesResponseModel[] GetPaymentTypes(string language);
        CapacitiesResponseModel[] GetCapacities(CapacitiesRequestModel model);
        VehicleTypeDetailsResponseModel GetVehicleTypeDetails(VehicleTypeDetailsRequestModel model);
        ExtraProductsResponseModel[] GetExtraProducts(ExtraProductsRequestModel model);
        ReservationSourcesResponseModel[] GetReservationSources();
        SendMailOnReservationInsertResponseModel SendMailOnReservationInsert(SendMailOnReservationInsertRequestModel model);
        OperationResultModel SendBankTransaction(SendBankTransactionRequestModel model);
        OperationResultModel InsertReservation(ReservationRequestModel model);
    }
}
