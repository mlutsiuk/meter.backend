using System.ComponentModel.DataAnnotations;

namespace Meter.Requests.Group;

public class GroupUpdateRequest
{
    [Required]
    public string Title { get; set; }
}