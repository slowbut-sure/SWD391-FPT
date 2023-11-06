﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ManagerApartment.Models;

public partial class Owner
{
    public int OwnerId { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Status { get; set; }

    public string? AvatarLink { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? LastUpdate { get; set; }

    [JsonInclude] public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
}
