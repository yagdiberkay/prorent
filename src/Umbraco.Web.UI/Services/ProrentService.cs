using Umbraco.Web.UI.Models;
using Umbraco.Web.UI.LiveProrent24Service;
using Umbraco.Core.Persistence.Mappers;
using System;

namespace Umbraco.Web.UI.Services
{

    public class ProrentService : IProrentService
    {
        private readonly Lazy<IMapperCollection> _mappers;
        public ProrentService(Lazy<IMapperCollection> mappers)
        {
            _mappers = mappers;
        }

        public OperationResultModel InsertReservation(ReservationModel model)
        {
            OperationResultModel result = new OperationResultModel();
            try
            {
                ReservationPortClient client = new ReservationPortClient();
                client.ClientCredentials.UserName.UserName = "testuser@prorent24.com";
                client.ClientCredentials.UserName.Password = "Tu123456";
                InsertReservationRequest insertReservationRequest = new InsertReservationRequest();
                //request model'e maplenecek

                //client.InsertReservationAsync(insertReservationRequest);
            }
            catch (System.Exception ex)
            {

                throw;
            }
            return result;
        }
    }
}
