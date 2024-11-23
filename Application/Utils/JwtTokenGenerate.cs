using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MusicG.Domain.Auth.Models;

namespace MusicG.Application.Utils;

public interface IJwtTokenGenerate
{
    string GenerateToken(AuthModel user, IConfiguration configuration);
}

public class JwtTokenGenerateImpl: IJwtTokenGenerate
{
    public string GenerateToken(AuthModel user, IConfiguration configuration)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Auth:KEY").Value!));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var jwt = new JwtSecurityToken(
            issuer: configuration.GetSection("Auth:ISSUER").Value,
            audience: configuration.GetSection("Auth:AUDIENCE").Value,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: cred
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}