using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.UI.Models;

namespace Umbraco.Web.UI.Services
{
    public interface IProrentService
    {
        OperationResultModel InsertReservation(ReservationModel model);
    }
}
