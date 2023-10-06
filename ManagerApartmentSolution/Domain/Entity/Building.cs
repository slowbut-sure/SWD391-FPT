using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class Building
{
    public int BuildingId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ApartmentType> ApartmentTypes { get; set; } = new List<ApartmentType>();

    public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
}
