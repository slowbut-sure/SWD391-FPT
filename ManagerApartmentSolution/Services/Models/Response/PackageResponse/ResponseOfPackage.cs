using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.PackageResponse
{
    public class ResponseOfPackage
    {
        public int PackageId { get; set; }

        public int ApartmentTypeId { get; set; }
        public string ApartmentTypeName {  get; set; }

        public string Code { get; set; }

        public string PackageName { get; set; }

        public string PackageDescription { get; set; }

        public decimal PackagePrice { get; set; }
    }
}
