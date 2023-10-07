using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.PackageResponse
{
    public class ResponseOfPackageServiceDetail
    {
        public int PackServiceDetailId { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal PackagePrice { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
