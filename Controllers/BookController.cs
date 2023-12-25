using Microsoft.AspNetCore.Mvc;
using Deneme1.Models;
using Deneme1.BookDbContext;

namespace Deneme1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpGet]
        public IActionResult BookList()
        {
            var db = new Database();
            if (db.Books == null) return BadRequest();
            return Ok(db.Books.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var db = new Database();
            if (db.Books == null) return BadRequest();

            var value = db.Books.Find(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddBook(Book b)
        {
            var db = new Database();
            db.Add(b);
            db.SaveChanges();
            return Ok(b);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            var db = new Database();
            if (db.Books == null) return BadRequest();
            var value = db.Books.Where(x => x.Id.Equals(id)).SingleOrDefault();
            if (value == null) return BadRequest();

            value.BookName = book.BookName;
            value.BookPage = book.BookPage;
            value.BookType = book.BookType;
            value.Status = book.Status;

            db.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOneBook(int id)
        {
            var db = new Database();
            if (db.Books == null) return BadRequest();
            var value = db.Books.Find(id);
            if (value == null) return BadRequest();
            db.Remove(value);
            db.SaveChanges();
            return Ok();
        }
    }
}