using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Meter.Auth;
using Meter.Dtos;
using Meter.Repositories;
using Meter.Requests.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("auth")]
[Authorize]
public class AuthController : Controller
{
    private readonly JwtAuthOptions _jwtAuthOptions;
    private readonly UserRepository _userRepository;

    public AuthController(JwtAuthOptions jwtAuthOptions, UserRepository userRepository)
    {
        _jwtAuthOptions = jwtAuthOptions;
        _userRepository = userRepository;
    }

    [Route("current")]
    [HttpGet]
    public async Task<IActionResult> Current()
    {
        string userIdString = User.Claims
            .ToList()
            .First(x => x.Type.Equals(ClaimTypes.Name))
            .Value;
        int userId = int.Parse(userIdString);


        return Json(await _userRepository.FindWithRole(userId));
    }

    [Route("login")]
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        UserWithRoleDto? user = await AuthenticateUser(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return Unauthorized();
        }

        return Ok(new
        {
            access_token = GenerateJwt(user)
        });
    }

    private async Task<UserWithRoleDto?> AuthenticateUser(string email, string password)
    {
        return await _userRepository.FindByCredentials(email, password);
    }

    private string GenerateJwt(UserWithRoleDto user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
        };

        var jwt = new JwtSecurityToken(
            issuer: _jwtAuthOptions.Issuer,
            audience: _jwtAuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(28)),
            signingCredentials: _jwtAuthOptions.GetSigningCredentials());

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}