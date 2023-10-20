using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Role { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? StaffStatus { get; set; }

    public string? AvatarLink { get; set; }

    public string? Code { get; set; }

    [JsonInclude] public virtual ICollection<StaffDetail> StaffDetails { get; set; } = new List<StaffDetail>();

    [JsonInclude] public virtual ICollection<StaffLog> StaffLogs { get; set; } = new List<StaffLog>();
}
