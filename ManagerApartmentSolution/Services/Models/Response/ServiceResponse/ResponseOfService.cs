using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.ServiceResponse
{
    public class ResponseOfService
    {
        public int ServiceId { get; set; }

        public string? Code { get; set; }

        public string? ServiceName { get; set; }

        public decimal? ServicePrice { get; set; }

        public string? Unit { get; set; }

        public string? ServiceStatus { get; set; }
    }
}
