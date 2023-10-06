using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.BuildingResponse
{
    public class ResponseOfBuilding
    {
        public int BuildingId { get; set; }

        public string Code { get; set; }

        public string BuildingName { get; set; }

        public string BuildingAddress { get; set; }

        public string BuildingStatus { get; set; }
    }
}
