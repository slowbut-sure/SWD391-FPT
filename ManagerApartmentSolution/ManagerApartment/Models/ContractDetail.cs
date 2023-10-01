using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class ContractDetail
{
    public int ContractDetailId { get; set; }

    public string? Code { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Tennant> Tennants { get; set; } = new List<Tennant>();
}
