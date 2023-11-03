using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class Request
{
    public int RequestId { get; set; }
    public int PackageId { get; set; }

    public int? ApartmentId { get; set; }
    public string? Description { get; set; }

    public DateTime? BookDateTime { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsSequence { get; set; }

    public int? Sequence { get; set; }

    public byte? ReqStatus { get; set; } // isDeleted



    [JsonInclude] public virtual ICollection<AddOn> AddOns { get; set; } = new List<AddOn>();

    [JsonInclude] public virtual Apartment? Apartment { get; set; }

    [JsonInclude] public virtual Package? Package { get; set; }

    [JsonInclude] public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    [JsonInclude] public virtual ICollection<RequestLog> RequestLogs { get; set; } = new List<RequestLog>();
}
