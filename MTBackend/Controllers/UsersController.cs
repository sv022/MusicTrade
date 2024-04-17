using System.Data.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MTBackend.Models;

namespace MTBackend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContent db;
        public UserController(AppDbContent context){
            db = context;
        }
        private static readonly List<User> items = new(){
            new User(101, "bob", 1, "phone", new DateTime(), "ex@mail.ru"),
            new User(102, "bob", 1, "phone", new DateTime(), "ex@mail.ru"),
            new User(103, "bob", 1, "phone", new DateTime(), "ex@mail.ru"),
        };

        [HttpGet("api/users")]
        public ActionResult<IEnumerable<User>> GetUsers(){
            var users = db.Users.Select(u => u).ToList();
            if (users == null) return NotFound();
            return users;  
        }

        [HttpGet("api/userstest")]
        public ActionResult<IEnumerable<User>> GetUsersTest(){
            if (items == null) return NotFound();
            return items;
        }
    }
}