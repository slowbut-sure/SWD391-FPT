using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class Apartment
{
    public int ApartmentId { get; set; }

    public int? ApartmentTypeId { get; set; }

    public int? BuildingId { get; set; }

    public int? OwnerId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int? Sequence { get; set; }

    public string? ApartmentStatus { get; set; }

    [JsonInclude] public virtual ApartmentType? ApartmentType { get; set; }

    [JsonInclude] public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [JsonInclude] public virtual Building? Building { get; set; }

    [JsonInclude] public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    [JsonInclude] public virtual Owner? Owner { get; set; }

    [JsonInclude] public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
