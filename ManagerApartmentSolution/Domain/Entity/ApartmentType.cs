using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class ApartmentType
{
    public int ApartmentTypeId { get; set; }

    public int? BuildingId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    [JsonInclude] public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();

    [JsonInclude] public virtual Building? Building { get; set; }

    [JsonInclude] public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
