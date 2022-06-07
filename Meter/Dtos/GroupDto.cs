﻿using System.Text.Json.Serialization;

namespace Meter.Dtos;

public class GroupDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public int OwnerId { get; set; }
    [JsonIgnore]
    public UserDto Owner { get; set; }
    
    public List<CounterDto> Counters { get; set; }
}