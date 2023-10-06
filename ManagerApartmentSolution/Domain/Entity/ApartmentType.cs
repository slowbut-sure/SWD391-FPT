using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class ApartmentType
{
    public int ApartmentTypeId { get; set; }

    public int? BuildingId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();

    public virtual Building? Building { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
