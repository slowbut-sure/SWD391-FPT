using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Unit { get; set; }

    public string? ServiceStatus { get; set; }

    [JsonInclude] public virtual ICollection<AddOn> AddOns { get; set; } = new List<AddOn>();

    [JsonInclude] public virtual ICollection<PackageServiceDetail> PackageServiceDetails { get; set; } = new List<PackageServiceDetail>();

    [JsonInclude] public virtual ICollection<StaffDetail> StaffDetails { get; set; } = new List<StaffDetail>();
}
