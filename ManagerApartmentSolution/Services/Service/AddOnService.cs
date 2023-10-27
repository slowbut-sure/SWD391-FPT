using Services.Models.Response.Response.AddOnResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface AddOnService
    {
        Task<List<ResponseOfAddOn>> GetAllAddOnss();
        Task<ResponseOfAddOn> GetAddOnById(int id);
    }
}
