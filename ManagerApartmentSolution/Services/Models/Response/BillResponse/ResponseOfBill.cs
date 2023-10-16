using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Bill
{
    public class ResponseOfBill
    {
        public int BillId { get; set; }
        public int RequestId { get; set; }

        public string BillDescription { get; set; }
        public DateTime BookDateTime { get; set; }
        public DateTime EndDate {  get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
