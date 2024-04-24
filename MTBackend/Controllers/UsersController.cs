using Microsoft.AspNetCore.Mvc;
using MTBackend.Models;


namespace MTBackend.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private AppDbContent db;
    public UserController(AppDbContent context){
        db = context;
    }

    [HttpGet("api/users")]
    public ActionResult<IEnumerable<object>> GetUsers(){
        var users = db.Users.Select(u => new {
            Id = u.Id,
            Email = u.Email,
            Phone = u.Phone,
            SignUpDate = u.Signupdate,
            City = u.City
            }).ToList();
        if (users == null) return NotFound();
        return users;  
    }
}