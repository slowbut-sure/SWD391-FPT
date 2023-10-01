using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class StaffDetail
{
    public int StaffDetailId { get; set; }

    public int? StaffId { get; set; }

    public int? ServiceId { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Staff? Staff { get; set; }
}
