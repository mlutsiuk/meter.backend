using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Meter.Auth;

public class JwtAuthOptions
{
    private readonly IConfiguration _configuration;
    
    public JwtAuthOptions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Issuer => _configuration["Authentication:JWT:Issuer"];
    public string Audience => _configuration["Authentication:JWT:Audience"];
    private string Key => _configuration["Authentication:JWT:Key"];

    public SigningCredentials GetSigningCredentials()
    {
        return new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
    }
    
    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}