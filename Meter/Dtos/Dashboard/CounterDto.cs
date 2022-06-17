namespace Meter.Dtos.Dashboard;

public class CounterDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    
    public int GroupId { get; set; }
    
    public int IconId { get; set; }
    public LastMeasureDto? LastMeasure { get; set; }
}