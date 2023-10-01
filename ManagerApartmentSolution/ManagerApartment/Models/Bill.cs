using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int? RequestId { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Status { get; set; }

    public virtual Request? Request { get; set; }
}
