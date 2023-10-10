using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.OwnerRequest
{
    public class UpdateOwner
    {
        public string OwnerCode { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPassword { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerStatus { get; set; }
    }
}
