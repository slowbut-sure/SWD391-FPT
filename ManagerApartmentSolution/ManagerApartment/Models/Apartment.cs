using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class Apartment
{
    public int ApartmentId { get; set; }

    public int? ApartmentTypeId { get; set; }

    public int? BuildingId { get; set; }

    public int? OwnerId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int? Sequence { get; set; }

    public string? ApartmentStatus { get; set; }

    public virtual ApartmentType? ApartmentType { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual Building? Building { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Owner? Owner { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
