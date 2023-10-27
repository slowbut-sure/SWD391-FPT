using ManagerApartment.Models;
using Services.Models.Response.Response.RequestRespponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface RequestDetailService
    {
        Task<List<ResponseOfRequestDetail>> GetAllRequestDetails();
        Task<ResponseOfRequestDetail> GetRequestDetailById(int id);
    }
}
