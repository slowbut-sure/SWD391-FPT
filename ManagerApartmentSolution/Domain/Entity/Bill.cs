using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int? RequestId { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Status { get; set; }

    [JsonInclude] public virtual Request? Request { get; set; }
}
