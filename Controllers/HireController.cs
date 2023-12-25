using Deneme1.BookDbContext;
using Deneme1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Deneme1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HireController : ControllerBase
    {
        [HttpGet]
        public IActionResult HireList()
        {
            var db = new Database();
            if (db.Hires == null) return BadRequest();
            return Ok(db.Hires.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetHire(int id)
        {
            var db = new Database();
            if (db.Hires == null) return BadRequest();

            var value = db.Hires.Find(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddHire(Hire h)
        {
            var db = new Database();
            db.Add(h);
            db.SaveChanges();
            return Ok(h);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateHire([FromRoute(Name = "id")] int id, [FromBody] Hire hire)
        {
            var db = new Database();
            if (db.Hires == null) return BadRequest();
            var value = db.Hires.Where(x => x.Id.Equals(id)).SingleOrDefault();
            if (value == null) return BadRequest();

            value.BookId = hire.BookId;
            value.TcNo = hire.TcNo;
            value.UserLastName = hire.UserLastName;
            value.UserName = hire.UserName;
            value.UserPhone = hire.UserPhone;

            db.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOneHire(int id)
        {
            var db = new Database();
            if (db.Hires == null) return BadRequest();
            var value = db.Hires.Find(id);
            if (value == null) return BadRequest();
            db.Remove(value);
            db.SaveChanges();
            return Ok();
        }
    }
}