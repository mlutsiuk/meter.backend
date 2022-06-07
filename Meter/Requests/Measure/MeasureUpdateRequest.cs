using System.ComponentModel.DataAnnotations;

namespace Meter.Requests.Measure;

public class MeasureUpdateRequest
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int Value { get; set; }
    
    [Required]
    public int CounterId { get; set; }
}