using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class ContractDetail
{
    public int ContractDetailId { get; set; }

    public string? Code { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [JsonInclude] public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    [JsonInclude] public virtual ICollection<Tennant> Tennants { get; set; } = new List<Tennant>();
}
