using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.TennantResponse
{
    public class ResponseOfTennant
    {
        public int TennantId { get; set; }
        public string TennantCode { get; set; }
        public string TennantName { get; set; }
        public string TennantEmail { get; set; }
        public string Password { get; set; }
        public string TennantStatus { get; set; }
        public string TennantPhone { get; set; }
        public string TennantAddress { get; set; }
        public int ContractDetailId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
