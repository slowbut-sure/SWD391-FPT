﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.ServiceResponse
{
    public class ResponseOfService
    {
        public int ServiceId { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceName { get; set; }

        public decimal ServicePrice { get; set; }

        public string ServiceUnit { get; set; }

        public string ServiceStatus { get; set; } 
    }
}
