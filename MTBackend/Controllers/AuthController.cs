using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MTBackend.Models;
using MTBackend.Services;


namespace MTBackend.Controllers;

[ApiController]
public class AuthController(AppDbContent context, ITokenService TokenService) : ControllerBase
{
    readonly private AppDbContent db = context;
    readonly private PasswordHasher Hasher = new();
    readonly private ITokenService tokenService = TokenService;

    [HttpPost("auth/register")]
    public IActionResult SignUp(UserSignUpBody Body){

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        var NewUser = new User (
            Body.Email, 
            Body.Username, 
            Hasher.Hash(Body.Password), 
            Body.City, 
            Body.Phone, 
            DateOnly.FromDateTime(DateTime.Now)
            );
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

        // Check avaliable Username
        var user = db.Users.SingleOrDefault(u => u.Username == NewUser.Username);
        if (user != null) return StatusCode(409);

        // Check avaliable Email
        user = db.Users.SingleOrDefault(u => u.Email == NewUser.Email);
        if (user != null) return StatusCode(409);

        try {
            db.Users.Add(NewUser);
            db.SaveChanges();
            return Ok();
        } catch (Exception e) {
            Console.WriteLine(e.InnerException?.Message);
            return BadRequest(new {e.InnerException?.Message});
        }
    }
    [HttpPost("auth/login")]
    public IActionResult Login(UserLoginBody body) {
        if (body == null) return BadRequest("No body recieved.");

        var user = db.Users.SingleOrDefault(u => u.Username == body.Username);
        if (user == null || !Hasher.Verify(body.Password + "", user.Password)) return BadRequest("Wrong password.");

        var usersClaims = new [] {
            new Claim(ClaimTypes.Name, user.Username),                
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var jwtToken = tokenService.GenerateAccessToken(usersClaims);
        var refreshToken = tokenService.GenerateRefreshToken();

        user.Refreshtoken = refreshToken;
        db.SaveChanges();

        return new ObjectResult(new {
            token = jwtToken,
            refreshToken = refreshToken
        });    
    }
}

