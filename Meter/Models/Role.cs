﻿using System.Text.Json.Serialization;

namespace Meter.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public List<User> Users { get; set; }

    public Role()
    {
        Users = new List<User>();
    }
}