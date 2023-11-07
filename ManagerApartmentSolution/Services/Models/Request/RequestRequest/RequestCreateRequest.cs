using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.RequestRequest
{
    public class RequestCreateRequest
    {
        public int ApartmentId { get; set; }
        public int PackageId { get; set; }
        public string RequestDescription { get; set; }
        public DateTime rqBookDateTime { get; set; }

    }
}
