using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.RequestRespponse
{
    public class ResponseOfRequest
    {
        public int RequestId { get; set; }
        public int ApartmentId { get; set; }
        public int PackageRequestedId { get; set; }
        public int OwnerId { get; set; }
        public string ApartmentName { get; set; }
        public string PackageName { get; set; }
        public string Owner { get; set; }
        public string ApartmentAddress { get; set; }

        public decimal PackagePrice { get; set; }

        public string Description { get; set; }

        public DateTime BookDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool IsSequence { get; set; }

        public int sequence { get; set; }

        public string ReqStatus {  get; set; }

        public int NumberOfAddOns { get; set; }
    }
}
