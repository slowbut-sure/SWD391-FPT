using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.RequestRespponse
{
    public class UpdateRequestLog
    {
        public int RequestId { get; set; }
        public string rqLogMaintainItem { get; set; }
        public string ReqLogDescription { get; set; }
        public string RqLogStatus { get; set; }
    }
}
