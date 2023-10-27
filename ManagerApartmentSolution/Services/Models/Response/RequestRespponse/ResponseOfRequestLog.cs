using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.RequestRespponse
{
    public class ResponseOfRequestLog
    {
        public int RequestLogId { get; set; }
        public int RequestId { get; set; }
        public string MaintainItem { get; set; }
        public string ReqLogDescription { get; set; }
        public string RqLogStatus { get; set; }
    }
}
