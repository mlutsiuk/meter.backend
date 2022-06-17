using System.Text.Json.Serialization;

namespace Meter.Dtos.Dashboard;

public class MyGroupsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public int OwnerId { get; set; }
    
    public IEnumerable<CounterDto> Counters { get; set; }

}