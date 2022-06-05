using System.ComponentModel.DataAnnotations;

namespace Meter.Requests.User;

public class UserUpdateRequest
{
    [Required]
    public int RoleId { get; set; }
}