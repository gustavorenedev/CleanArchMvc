using CleanArchMvc.API.DTOs;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchMvc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authenticate;
    private readonly IConfiguration _configuration;

    public TokenController(IAuthenticate authenticate, IConfiguration configuration)
    {
        _authenticate = authenticate;
        _configuration = configuration;
    }

    [HttpPost("RegisterUser")]
    public async Task<ActionResult<UserToken>> Register([FromBody] LoginDTO loginDTO)
    {
        var result = await _authenticate.RegisterUser(loginDTO.Email!, loginDTO.Password!);

        if (result)
        {
            return Ok($"User {loginDTO.Email} was create successfully");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid Register attempt.");
            return BadRequest(ModelState);
        }
    }


    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginDTO loginDTO)
    {
        var result = await _authenticate.Authenticate(loginDTO.Email!, loginDTO.Password!);

        if (result)
        {
            return GenerateToken(loginDTO);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
            return BadRequest(ModelState);
        }
    }

    private ActionResult<UserToken> GenerateToken(LoginDTO loginDTO)
    {
        var claims = new[]
        {
            new Claim("email", loginDTO.Email!),
            new Claim("myvalue", "anything"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(10);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
            );

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration,
        };
    }
}
