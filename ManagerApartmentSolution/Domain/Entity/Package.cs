using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class Package
{
    public int PackageId { get; set; }

    public int? ApartmentTypeId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? PackageImageLink { get; set; }

    public decimal Price { get; set; }

    [JsonInclude] public virtual ApartmentType? ApartmentType { get; set; }

    [JsonInclude] public virtual ICollection<PackageServiceDetail> PackageServiceDetails { get; set; } = new List<PackageServiceDetail>();
    [JsonInclude] public virtual ICollection<Request> Requests { get; set; } = new List<Request>();


    //[JsonInclude] public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();
}
