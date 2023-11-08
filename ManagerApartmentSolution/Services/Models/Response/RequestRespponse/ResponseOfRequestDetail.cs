using ManagerApartment.Models;
using Services.Models.Response.Response.AddOnResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.RequestRespponse
{
    public class ResponseOfRequestDetail : ResponseOfRequest
    {
       public List<ResponseOfAddOn>? AddOnsList { get; set; }
    }
}
