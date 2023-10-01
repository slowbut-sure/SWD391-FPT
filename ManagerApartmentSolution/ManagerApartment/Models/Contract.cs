using System;
using System.Collections.Generic;

namespace ManagerApartment.Models;

public partial class Contract
{
    public int ContractId { get; set; }

    public int? ApartmentId { get; set; }

    public int? ContractDetailId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? ContractImage { get; set; }

    public string? ContractStatus { get; set; }

    public virtual Apartment? Apartment { get; set; }

    public virtual ContractDetail? ContractDetail { get; set; }
}
