using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Revival.Books.Data;

namespace Revival.Books.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {    
        private readonly ILogger<BooksController> _logger;

        private readonly RevivalBooksDbContext _db;

        public BooksController(ILogger<BooksController> logger)
            => (_logger) = (logger);
        public BooksController(RevivalBooksDbContext db)
            => (_db) = (db);
        
        public BooksController(ILogger<BooksController> logger, RevivalBooksDbContext db)
            => (_logger, _db) = (logger, db);
        
        [HttpGet("/api/books")]
        public ActionResult GetBooks()
        {
            var books = _db.Books.ToList();
            
            return Ok("Books!");
        }
        [HttpPost]
        public void Post()
        {

        }
    }
}
