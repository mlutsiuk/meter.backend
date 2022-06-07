using System.ComponentModel.DataAnnotations;

namespace Meter.Requests.Icon;

public class IconCreateRequest
{
    [Required]
    public string Code { get; set; }
}