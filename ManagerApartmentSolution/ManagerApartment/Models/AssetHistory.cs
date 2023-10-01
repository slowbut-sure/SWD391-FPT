using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class AssetHistory
{
    public int AssetHistoryId { get; set; }

    public string? Code { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public string? ItemImage { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
