using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using NullAction.Filters;

namespace NullAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly List<Book> _books = new List<Book> {
            new Book(1, "CLR via C#"),
            new Book(2, ".NET Core Programming")
        };

        [HttpGet("{id}")]
        [ShortCircuitingFilter]
        [NotFoundActionFilter]
        [NotFoundAlwaysRunFilter]
        public IActionResult GetById(int id)
        {
            var item = _books.FirstOrDefault(p => p.BookId == id);
            return Ok(item);
        }

        //[HttpGet("{id}")]
        //public ActionResult<Book> GetById(int id)
        //{
        //    var book = _books.FirstOrDefault(p => p.BookId == id);
        //    return book;
        //}

        //[HttpGet("{id}")]
        //public Book GetById(int id)
        //{
        //    var book = _books.FirstOrDefault(p => p.BookId == id);
        //    return book;
        //}
    }

    public class Book
    {
        public Book(int bookId, string bookName)
        {
            BookId = bookId;
            BookName = bookName;
        }

        public int BookId { get; set; }

        public string BookName { get; set; }
    }
}