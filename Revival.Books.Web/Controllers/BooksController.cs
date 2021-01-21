using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Revival.Books.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {    
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("/api/books")]
        public ActionResult GetBooks()
        {
            return Ok("Books!");
        }
        [HttpPost]
        public void Post()
        {

        }
    }
}
