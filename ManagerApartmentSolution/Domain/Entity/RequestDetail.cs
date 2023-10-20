using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class RequestDetail
{
    public int RequestDetailId { get; set; }

    public int? RequestId { get; set; }

    public int? PackageId { get; set; }

    public int? Amount { get; set; }

    public decimal? Price { get; set; }

    [JsonInclude] public virtual Package? Package { get; set; }

    [JsonInclude] public virtual Request? Request { get; set; }
}
