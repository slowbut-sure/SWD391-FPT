﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.ApartmentResponse
{
    public class ResponseOfApartment
    {
        public int ApartmentId { get; set; }    
        public int ApartmentTypeId { get; set; }
        public string apTypeName { get; set; } = null!;
        public int BuildingId { get; set; }
        public string BuildingName { get; set; } = null!;
        public int OwnerId {  get; set; }
        public string OwnerCode { get; set; } = null!;
        public string OwnerName { get; set; } = null!;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Sequence { get; set; }
        public string ApartmentStatus { get; set; }
        public string BuildingAddress {  get; set; }

    }
}
