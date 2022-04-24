using Umbraco.Web.UI.Models;
using Umbraco.Web.UI.TestProrent24Service;
using Mapster;
using System.Web.Configuration;
using System.ServiceModel.Security;

namespace Umbraco.Web.UI.Services
{

    public class ProrentService : IProrentService
    {
        string prorentServiceUsername = WebConfigurationManager.AppSettings["ProrentServiceUsername"].ToString();
        string prorentServiceUserPassword = WebConfigurationManager.AppSettings["ProrentServicePassword"].ToString();

        public ReservationPortClient ProrentServiceClient()
        {

            ReservationPortClient client = new ReservationPortClient();
            try
            {

                var factory = new System.ServiceModel.ChannelFactory<ReservationPort>();

                factory.Endpoint.Address = client.Endpoint.Address;
                factory.Endpoint.Binding = client.Endpoint.Binding;

                var channel = factory.CreateChannel();

                client.ChannelFactory.Credentials.UserName.UserName = prorentServiceUsername;
                client.ChannelFactory.Credentials.UserName.Password = prorentServiceUserPassword;
                client.ClientCredentials.UserName.UserName = prorentServiceUsername;
                client.ClientCredentials.UserName.Password = prorentServiceUserPassword;
                client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
                  new X509ServiceCertificateAuthentication()
                  {
                      CertificateValidationMode = X509CertificateValidationMode.None,
                      RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                  };
            }
            catch (System.Exception ex)
            {

                throw;
            }

            return client;
        }
        public CitiesResponseModel[] GetCities(string countryCode)
        {

            CitiesResponseModel[] result = new CitiesResponseModel[0];
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                CitiesRequest citiesRequest = new CitiesRequest
                {
                    countryCode = countryCode
                };
                var response = client.CitiesAsync(citiesRequest);
                result = response.Result.CitiesResponse1.Adapt<CitiesResponseModel[]>();
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public CountriesResponseModel[] GetCountries(string language)
        {

            CountriesResponseModel[] result = new CountriesResponseModel[0];
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                CountriesRequest countriesRequest = new CountriesRequest
                {
                    language = language
                };
                var response = client.CountriesAsync(countriesRequest);
                result = response.Result.CountriesResponse1.Adapt<CountriesResponseModel[]>();
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public CurrenciesResponseModel[] GetCurrencies()
        {
            CurrenciesResponseModel[] result = new CurrenciesResponseModel[0];
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                CurrenciesRequest currenciesRequest = new CurrenciesRequest();

                var response = client.CurrenciesAsync(currenciesRequest);
                result = response.Result.CurrenciesResponse1.Adapt<CurrenciesResponseModel[]>();
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public LocationsResponseModel[] GetLocations(LocationsRequestModel model)
        {
            LocationsResponseModel[] result = new LocationsResponseModel[0];
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                LocationsRequest locationsRequest = new LocationsRequest();
                locationsRequest = model.Adapt<LocationsRequest>();

                var response = client.LocationsAsync(locationsRequest);
                result = response.Adapt<LocationsResponseModel[]>();
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public CampaignsResponseModel[] GetCampaigns(CampaignsRequestModel model)
        {
            CampaignsResponseModel[] result = new CampaignsResponseModel[0];
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                CampaignsRequest campaignsRequest = new CampaignsRequest();
                campaignsRequest = model.Adapt<CampaignsRequest>();
                var response = client.CampaignsAsync(campaignsRequest);
                result = response.Result.Adapt<CampaignsResponseModel[]>();
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public TariffsResponseModel[] GetTariffs()
        {
            TariffsResponseModel[] result = new TariffsResponseModel[0];
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                TariffsRequest tariffsRequest = new TariffsRequest();
                var response = client.Tariffs(tariffsRequest);
                result = response.Adapt<TariffsResponseModel[]>();
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public PaymentTypesResponseModel[] GetPaymentTypes(string language)
        {
            PaymentTypesResponseModel[] result = new PaymentTypesResponseModel[0];
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                PaymentTypesRequest paymentTypesRequest = new PaymentTypesRequest();
                paymentTypesRequest.language = language;
                var response = client.PaymentTypes(paymentTypesRequest);
                result = response.Adapt<PaymentTypesResponseModel[]>();
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public SendMailOnReservationInsertResponseModel SendMailOnReservationInsertResponse(SendMailOnReservationInsertRequestModel model)
        {
            SendMailOnReservationInsertResponseModel result = new SendMailOnReservationInsertResponseModel();
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                SendMailOnReservationInsertRequest sendMailOnReservationInsert = new SendMailOnReservationInsertRequest();
                sendMailOnReservationInsert = model.Adapt<SendMailOnReservationInsertRequest>();
                var response = client.SendMailOnReservationInsert(sendMailOnReservationInsert);
                result = response.Adapt<SendMailOnReservationInsertResponseModel>();
            }
            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public OperationResultModel InsertReservation(ReservationModel model)
        {
            var data = model.Adapt<reservation>();
            OperationResultModel result = new OperationResultModel();
            try
            {
                ReservationPortClient client = ProrentServiceClient();
                InsertReservationRequest insertReservationRequest = new InsertReservationRequest
                {
                    reservation = data
                };
                var response = client.InsertReservationAsync(insertReservationRequest);
                result = response.Result.InsertReservationResponse.Adapt<OperationResultModel>();
            }
            catch (System.Exception ex)
            {
                throw;
            }
            return result;
        }


    }
}
