namespace Meter.Dtos;

public class MeasureDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Value { get; set; }
    
    public int CounterId { get; set; }
    public CounterDto Counter { get; set; }
}