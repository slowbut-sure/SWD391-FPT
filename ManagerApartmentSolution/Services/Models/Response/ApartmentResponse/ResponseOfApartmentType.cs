using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.ApartmentResponse
{
    public class ResponseOfApartmentType
    {
        public int ApartmentTypeId { get; set; }

        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string BuildingAddress { get; set; }

        public string ApartmentTypeName { get; set; }

        public string ApaermentTypeDescription { get; set; }

        public string Status { get; set; }
    }
}
