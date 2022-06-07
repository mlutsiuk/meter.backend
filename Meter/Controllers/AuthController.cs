using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Meter.Auth;
using Meter.Models;
using Meter.Repositories;
using Meter.Requests.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meter.Controllers;

[Route("auth")]
[Authorize]
public class AuthController : Controller
{
    private readonly AppDbContext _context;
    private readonly JwtAuthOptions _jwtAuthOptions;
    private readonly UserRepository _userRepository;

    public AuthController(AppDbContext context, JwtAuthOptions jwtAuthOptions, UserRepository userRepository)
    {
        _context = context;
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


        return Json(await _userRepository.Find(userId));
    }

    [Route("login")]
    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
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
        return _context.Users.Include(user => user.Role)
            .FirstOrDefault(user => user.Email == email && user.Password == password);
    }

    private string GenerateJwt(User user)
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