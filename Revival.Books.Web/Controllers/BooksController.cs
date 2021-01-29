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

        [HttpGet("/api/books/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBook(id);
            return Ok(book);
        }

        [HttpPost("/api/books")]
        public ActionResult CreateBook([FromBody] NewBookRequest bookRequest)
        {
            var now = DateTime.UtcNow;
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
        
        [HttpPatch("/api/books/{id}")]
        public async Task<IActionResult> UpdateBookById(int id, [FromBody]NewBookRequest newBook)
        {
            // TODO: Take out the logic with services from controller
            var updatebleBook = await _bookService.GetBook(id);

            var newUpdateBook = updatebleBook;
            newUpdateBook.Author = newBook.Author;
            newUpdateBook.Title = newBook.Title;

            await _bookService.UpdateBook(id, newUpdateBook); 

            return Ok(newUpdateBook);
        } 
        
        [HttpDelete("/api/books/{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            await _bookService.DeleteBook(id);
            return Ok($"Book deleted with ID: {id}");
        }
    }
}
