using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.OwnerResponse
{
    public class ResponseOfOwner
    {
        public int OwnerId { get; set; }

        public string Code { get; set; }

        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; }

        public string Password { get; set; }

        public string OwnerPhone { get; set; }

        public string OwnerAddress { get; set; }

        public string OwnerStatus { get; set; }
    }
}
