using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.RequestRequest
{
    public class RequestRequestLog
    {
        public int RequestId { get; set; }
        public string? MaintainItem { get;set; }
        public string? Description { get; set; }

        public int StaffId { get; set; }

        public string Status { get; set; }
    }
}
