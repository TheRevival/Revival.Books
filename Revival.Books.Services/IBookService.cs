using Revival.Books.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revival.Books.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync();
        public Task<Book> GetBookAsync(int bookId);
        public Task AddBookAsync(Book book);
        public Task DeleteBookAsync(int bookId);
    }
}