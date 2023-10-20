using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class PackageServiceDetail
{
    public int PackSerDetailId { get; set; }

    public int? ServiceId { get; set; }

    public int? PackageId { get; set; }

    [JsonInclude] public virtual Package? Package { get; set; }

    [JsonInclude] public virtual Service? Service { get; set; }
}
