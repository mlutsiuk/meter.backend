namespace Meter.Models;

public class Measure
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Value { get; set; }
    
    public int CounterId { get; set; }
    public Counter Counter { get; set; }
}