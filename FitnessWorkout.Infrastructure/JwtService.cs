using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FitnessWorkout.Application;
using FitnessWorkout.Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitnessWorkout.Infrastructure;

public class JwtService(IConfiguration configuration) : IJwtService
{
    private readonly IConfiguration _configuration = configuration;

    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthConfiguration:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claim = new List<Claim>();
        claim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claim.Add(new Claim(ClaimTypes.Email, user.Email ?? ""));
        var handler = new JwtSecurityTokenHandler();
        var token = new JwtSecurityToken(issuer : configuration["AuthConfiguration:Issuer"],
            _configuration["AuthConfiguration:Audience"], claims : claim,
            expires : DateTime.Now.AddMinutes(60), signingCredentials: credentials);

        return handler.WriteToken(token);
    }
}