using System.Text.Json.Serialization;

namespace Meter.Dtos;

public class CounterDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    
    public int GroupId { get; set; }
    [JsonIgnore]
    public GroupDto Group { get; set; }
    
    public int IconId { get; set; }
    public IconDto Icon { get; set; }
    
    [JsonIgnore]
    public List<MeasureDto> Measures { get; set; }
}