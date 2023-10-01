using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class Tennant
{
    public int TennantId { get; set; }

    public int? ContractDetailId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Status { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ContractDetail? ContractDetail { get; set; }
}
