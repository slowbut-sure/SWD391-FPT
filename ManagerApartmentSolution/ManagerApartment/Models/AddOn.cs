using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class AddOn
{
    public int AddOnId { get; set; }

    public int? RequestId { get; set; }

    public int? ServiceId { get; set; }

    public int? Amount { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public virtual Request? Request { get; set; }

    public virtual Service? Service { get; set; }
}
