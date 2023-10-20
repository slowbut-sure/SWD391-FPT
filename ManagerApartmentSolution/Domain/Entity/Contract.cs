using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

    [JsonInclude] public virtual Apartment? Apartment { get; set; }

    [JsonInclude] public virtual ContractDetail? ContractDetail { get; set; }
}
