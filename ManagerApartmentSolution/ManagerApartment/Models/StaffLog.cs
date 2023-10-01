using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class StaffLog
{
    public int StaffLogId { get; set; }

    public int? StaffId { get; set; }

    public int? RequestLogId { get; set; }

    public virtual RequestLog? RequestLog { get; set; }

    public virtual Staff? Staff { get; set; }
}
