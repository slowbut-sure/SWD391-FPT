using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.RequestRespponse
{
    public class ResponseOfRequestDetail
    {
        public int RequestDetailId { get; set; }

        public int? RequestId { get; set; }
        public string? RequestDescription { get; set; }
        public DateTime? BookDateTime { get; set; }
        public DateTime? EndDate { get; set; }

        public int? PackageId { get; set; }
        public string PackageName { get; set; } 

        public int? RequestDetailAmount { get; set; }

        public decimal? RequestPrice { get; set; }
    }
}
