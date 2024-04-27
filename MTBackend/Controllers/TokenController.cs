using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MTBackend.Models;
using MTBackend.Services;

namespace RefreshTokensWebApiExample.Controllers;

[ApiController]
public class TokenController : ControllerBase
{
    private readonly ITokenService _tokenService;
    readonly private AppDbContent db;
    readonly private PasswordHasher Hasher = new();
    public TokenController(ITokenService tokenService, AppDbContent content) {
        _tokenService = tokenService;
        db = content;
    }

    [HttpPost("token/refresh")]
    public async Task<IActionResult> Refresh(string token, string refreshToken)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(token);
        var username = principal?.Identity?.Name; //this is mapped to the Name claim by default

        var user = db.Users.SingleOrDefault(u => u.Username == username);
        if (user == null || user.Refreshtoken != refreshToken) return BadRequest();

    #pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.

        var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);

    #pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.

        var newRefreshToken = _tokenService.GenerateRefreshToken();

        user.Refreshtoken = newRefreshToken;
        await db.SaveChangesAsync();

        return new ObjectResult(new {
            token = newJwtToken,
            refreshToken = newRefreshToken
        });
    }

    [HttpPost("token/revoke"), Authorize]
    public async Task<IActionResult> Revoke()
    {
        var username = User?.Identity?.Name;

        var user = db.Users.SingleOrDefault(u => u.Username == username);
        if (user == null) return BadRequest();

        user.Refreshtoken = "";

        await db.SaveChangesAsync();
        return NoContent();
    }
}
