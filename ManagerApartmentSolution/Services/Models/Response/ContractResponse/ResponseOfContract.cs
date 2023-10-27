using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.ContractResponse
{
    public class ResponseOfContract
    {
        public int ContractId { get; set; }

        public int ApartmentId { get; set; }

        public int ContractDetailId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string ContractImage { get; set; }

        public string ContractStatus { get; set; }
    }
}
