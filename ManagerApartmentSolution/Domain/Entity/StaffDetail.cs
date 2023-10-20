using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class StaffDetail
{
    public int StaffDetailId { get; set; }

    public int? StaffId { get; set; }

    public int? ServiceId { get; set; }

    [JsonInclude] public virtual Service? Service { get; set; }

    [JsonInclude] public virtual Staff? Staff { get; set; }
}
