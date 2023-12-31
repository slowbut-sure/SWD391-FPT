﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

    [JsonInclude] public virtual Apartment? Apartment { get; set; }

    [JsonInclude] public virtual AssetHistory? AssetHistory { get; set; }
}
