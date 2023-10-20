using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class StaffLog
{
    public int StaffLogId { get; set; }

    public int? StaffId { get; set; }

    public int? RequestLogId { get; set; }

    [JsonInclude] public virtual RequestLog? RequestLog { get; set; }

    [JsonInclude] public virtual Staff? Staff { get; set; }
}
