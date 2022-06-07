using System.Text.Json.Serialization;

namespace Meter.Dtos;

public class IconDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    
    [JsonIgnore]
    public List<CounterDto> Counters { get; set; }
}