namespace Meter.Dtos.Dashboard;

public class LastMeasureDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Value { get; set; }
    
    public int CounterId { get; set; }
}