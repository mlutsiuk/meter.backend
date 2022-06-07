using System.ComponentModel.DataAnnotations;

namespace Meter.Requests.Group;

public class GroupCreateRequest
{
    [Required]
    public string Title { get; set; }
    [Required]
    public int OwnerId { get; set; }
}