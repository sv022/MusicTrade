using Microsoft.AspNetCore.Mvc;
using MTBackend.Models;
using MTBackend.Utilities;


namespace MTBackend.Controllers;

[ApiController]
public class AuthController(AppDbContent context) : ControllerBase
{
    readonly private AppDbContent db = context;
    readonly private PasswordHasher Hasher = new();

    [HttpPost("auth/register")]
    public IActionResult Register(UserRegisterBody Body){

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

