using Deneme1.BookDbContext;
using Deneme1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Deneme1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult BookList()
        {
            var db = new Database();
            if (db.Users == null) return BadRequest();
            return Ok(db.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var db = new Database();
            if (db.Users == null) return BadRequest();

            var value = db.Users.Find(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddUser(User u)
        {
            var db = new Database();
            db.Add(u);
            db.SaveChanges();
            return Ok(u);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] User user)
        {
            var db = new Database();
            if (db.Users == null) return BadRequest();
            var value = db.Users.Where(x => x.Id.Equals(id)).SingleOrDefault();
            if (value == null) return BadRequest();

            value.UserName = user.UserName;
            value.UserLastName = user.UserLastName;
            value.TcNo = user.TcNo;
            value.UserAge = user.UserAge;
            value.UserCity = user.UserCity;
            value.UserPhone = user.UserPhone;

            db.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOneUser(int id)
        {
            var db = new Database();
            if (db.Users == null) return BadRequest();
            var value = db.Users.Find(id);
            if (value == null) return BadRequest();
            db.Remove(value);
            db.SaveChanges();
            return Ok();
        }
    }
}