using System.ComponentModel.DataAnnotations;

namespace Meter.Requests.Icon;

public class IconUpdateRequest
{
    [Required]
    public string Code { get; set; }
}