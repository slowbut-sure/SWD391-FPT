using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.AddOnResponse
{
    public class ResponseOfAddOn
    {
        public int AddOnId { get; set; }
        public int RequestId { get; set; }
        public string RequestDescription { get; set; }
        public DateTime RequestBookDate { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int ServicePrice { get; set; }
        public int AddonAmount { get; set; }
        public decimal AddOnPrice { get; set; }
        public string AddOnStatus { get; set; }
    }
}
