using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
        var NewUser = new User();
        NewUser.Email = Body.Email;
        NewUser.Username = Body.Username; 
        NewUser.Password = Hasher.Hash(Body.Password);
        NewUser.City = Body.City; 
        NewUser.Phone = Body.Phone; 
        NewUser.Signupdate = DateOnly.FromDateTime(DateTime.Now);
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

    [HttpGet("auth/me"), Authorize]
    public IActionResult Me() {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

        var user = db.Users.SingleOrDefault(u => u.Id == int.Parse(userId));

        if (user != null) return Ok(user);
        else return NotFound("User not found");
    }
}

