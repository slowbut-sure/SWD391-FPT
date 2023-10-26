using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial  class Building
{
    public Building()
    {
        Apartments = new HashSet<Apartment>();
    }
    public int BuildingId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Status { get; set; }

    //[JsonInclude] public virtual ICollection<ApartmentType> ApartmentTypes { get; set; } = new List<ApartmentType>();

    [JsonInclude]public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
}
