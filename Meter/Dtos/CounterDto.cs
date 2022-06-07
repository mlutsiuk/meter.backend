namespace Meter.Dtos;

public class CounterDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    
    public int GroupId { get; set; }
    public GroupDto Group { get; set; }
    
    public int IconId { get; set; }
    public IconDto Icon { get; set; }
    
    public List<MeasureDto> Measures { get; set; }
}