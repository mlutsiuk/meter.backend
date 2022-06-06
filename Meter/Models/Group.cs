namespace Meter.Models;

public class Group
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public int OwnerId { get; set; }
    public User Owner { get; set; }
    
    public List<Counter> Counters { get; set; }

    public Group()
    {
        Counters = new List<Counter>();
    }
}