﻿namespace Meter.Models;

public class Counter
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    
    public int GroupId { get; set; }
    public Group Group { get; set; }
    
    public int IconId { get; set; }
    public Icon Icon { get; set; }
    
    public List<Measure> Measures { get; set; }

    public Counter()
    {
        Measures = new List<Measure>();
    }
}