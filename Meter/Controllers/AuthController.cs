using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Meter.Auth;
using Meter.Models;
using Meter.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("auth")]
public class AuthController : Controller
{
    private readonly AppDbContext _context;
    private readonly JwtAuthOptions _jwtAuthOptions;

    public AuthController(AppDbContext context, JwtAuthOptions jwtAuthOptions)
    {
        _context = context;
        _jwtAuthOptions = jwtAuthOptions;
    }

    [Route("current")]
    [HttpGet]
    public IActionResult Current()
    {
        return Json(HttpContext.User);
    }
    
    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody]LoginRequest loginRequest)
    {
        User? user = AuthenticateUser(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return Unauthorized();
        }
        
        return Ok(new
        {
            access_token = GenerateJwt(user)
        });
    }

    private User? AuthenticateUser(string email, string password)
    {
        return _context.Users.FirstOrDefault(user => user.Email == email && user.Password == password);
    }

    private string GenerateJwt(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
        };
        
        var jwt = new JwtSecurityToken(
            issuer: _jwtAuthOptions.Issuer,
            audience: _jwtAuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: _jwtAuthOptions.GetSigningCredentials());

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}