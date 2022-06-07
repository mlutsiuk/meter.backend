namespace Meter.Dtos;

public class IconDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    
    public List<CounterDto> Counters { get; set; }
}