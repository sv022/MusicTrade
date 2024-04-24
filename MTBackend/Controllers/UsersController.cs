using System.Data.Common;
using Microsoft.AspNetCore.Cors;
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
    public ActionResult<IEnumerable<User>> GetUsers(){
        var users = db.Users.Select(u => u).ToList();
        if (users == null) return NotFound();
        return users;  
    }
}