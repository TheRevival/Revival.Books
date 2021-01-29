using Revival.Books.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revival.Books.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> GetBook(int bookId);
        public Task AddBook(Book book);
        public Task DeleteBook(int bookId);
        public Task UpdateBook(int bookId, Book newBook);
    }
}