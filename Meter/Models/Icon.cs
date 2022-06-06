namespace Meter.Models;

public class Icon
{
    public int Id { get; set; }
    public string Code { get; set; }
    
    public List<Counter> Counters { get; set; }

    public Icon()
    {
        Counters = new List<Counter>();
    }
}