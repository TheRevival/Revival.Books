using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Revival.Books.Data.Models;
using Revival.Books.Services;
using Revival.Books.Web.RequestModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Revival.Books.Web.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        private readonly IBookService _bookService;
        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("/api/books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost("/api/books")]
        public ActionResult CreateBook([FromBody] NewBookRequest bookRequest)
        {
            var now = DateTime.Now;
            var book = new Book
            {
                CreatedOn = now,
                UpdatedOn = now,
                Title = bookRequest.Title,
                Author = bookRequest.Author
            };

            _bookService.AddBook(book);

            return Ok($"Book created: {book.Title}");
        }
    }
}
