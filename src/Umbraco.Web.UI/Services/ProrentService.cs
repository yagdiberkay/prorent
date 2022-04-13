using Umbraco.Web.UI.Models;
using Umbraco.Web.UI.LiveProrent24Service;
using System;
using Umbraco.Web.UI.Mapping;
using AutoMapper;

namespace Umbraco.Web.UI.Services
{

    public class ProrentService : IProrentService
    {
        Umbraco.Web.UI.Mapping.Mapping _mapping;
        private IMapper _mapper;
        public ProrentService(IMapper mapper)
        {
            _mapping = new Umbraco.Web.UI.Mapping.Mapping();
            _mapper = mapper;
        }

        public OperationResultModel InsertReservation(ReservationModel model)
        {
            OperationResultModel result = new OperationResultModel();
            try
            {
                _mapper = _mapping.MappingConfig().CreateMapper();
                var data = _mapper.Map<ReservationModel, reservation>(model);
                ReservationPortClient client = new ReservationPortClient();
                client.ClientCredentials.UserName.UserName = "testuser@prorent24.com";
                client.ClientCredentials.UserName.Password = "Tu123456";
                InsertReservationRequest insertReservationRequest = new InsertReservationRequest
                {
                    reservation = data
                };
                var response = client.InsertReservationAsync(insertReservationRequest);
                result = _mapper.Map<InsertReservationResponse1, OperationResultModel>(response.Result);
            }
            catch (System.Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
