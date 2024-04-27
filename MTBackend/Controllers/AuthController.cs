using Microsoft.AspNetCore.Mvc;
using MTBackend.Models;
using MTBackend.Utilities;


namespace MTBackend.Controllers;

[ApiController]
public class AuthController(AppDbContent context, ITokenService tokenService) : ControllerBase
{
    readonly private AppDbContent db = context;
    readonly private PasswordHasher Hasher = new();
    readonly private ITokenService tokenService = tokenService;

    [HttpPost("auth/register")]
    public IActionResult SignUp(UserRegisterBody Body){

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

}

