using System.ComponentModel.DataAnnotations;

namespace Meter.Requests.Counter;

public class CounterCreateRequest
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Color { get; set; }
    
    [Required]
    public int GroupId { get; set; }

    [Required]
    public int IconId { get; set; }
}