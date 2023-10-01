using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class Package
{
    public int PackageId { get; set; }

    public int? ApartmentTypeId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public virtual ApartmentType? ApartmentType { get; set; }

    public virtual ICollection<PackageServiceDetail> PackageServiceDetails { get; set; } = new List<PackageServiceDetail>();

    public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();
}
