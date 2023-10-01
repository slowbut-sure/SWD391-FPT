using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Unit { get; set; }

    public string? ServiceStatus { get; set; }

    public virtual ICollection<AddOn> AddOns { get; set; } = new List<AddOn>();

    public virtual ICollection<PackageServiceDetail> PackageServiceDetails { get; set; } = new List<PackageServiceDetail>();

    public virtual ICollection<StaffDetail> StaffDetails { get; set; } = new List<StaffDetail>();
}
