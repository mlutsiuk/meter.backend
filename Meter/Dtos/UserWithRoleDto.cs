using System.Text.Json.Serialization;

namespace Meter.Dtos;

public class UserWithRoleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Avatar { get; set; }
    
    public int RoleId { get; set; }
    public RoleDto Role { get; set; }
}