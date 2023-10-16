using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.RequestDetailRequest
{
    public class UpdateRequestDetail
    {
        public int RequestId { get; set; }
        public int PackageId { get; set; }
        public int RequestDetailAmount { get; set; }
        public decimal? RequestPrice { get; set; }
    }
}
