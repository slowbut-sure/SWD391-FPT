using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class Asset
{
    public int AssetId { get; set; }

    public int? AssetHistoryId { get; set; }

    public int? ApartmentId { get; set; }

    public string? Name { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public string? ItemImage { get; set; }

    public string? Status { get; set; }

    public virtual Apartment? Apartment { get; set; }

    public virtual AssetHistory? AssetHistory { get; set; }
}
