using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.StaffResponse
{
    public class ResponseOfStaffLog
    {
        public int StaffLogId { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; } 
        public string StaffStatus { get; set; }
        public string StaffRole { get; set; }
        public int RequestLogId { get; set; }
        public int RequestId { get; set; }
        public string rqLogMaintainItem { get; set; }
        public string ReqLogDescription { get; set; }
        public string ReqLogStatus { get; set; }
    }
}
