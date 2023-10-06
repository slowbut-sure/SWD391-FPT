using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class PackageServiceDetail
{
    public int PackSerDetailId { get; set; }

    public int? ServiceId { get; set; }

    public int? PackageId { get; set; }

    public virtual Package? Package { get; set; }

    public virtual Service? Service { get; set; }
}
