using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.BuildingRequest
{
    public class RequestCreateBuilding
    {
        public string BuildingCode { get; set; }

        public string BuildingName { get; set; }

        public string BuildingAddress { get; set; }

    }
}
