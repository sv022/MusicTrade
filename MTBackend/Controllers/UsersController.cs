using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("api/user/{id}")]
    public ActionResult<IEnumerable<object>> GetUser(int Id){
        var user = db.Users.Where(u => u.Id == Id).SingleOrDefault();
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPatch("api/user"), Authorize]
    public ActionResult<IEnumerable<object>> PatchUser(User newUser){
        int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        try {
            var user = db.Users.Where(u => u.Id == userId).SingleOrDefault();
            user = newUser;
            db.Users.Update(user);
            db.SaveChanges();
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
        return Ok();
    }
}