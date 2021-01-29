using Microsoft.EntityFrameworkCore;
using Revival.Books.Data;
using Revival.Books.Data.Models;
using Revival.Books.Services.Helpers.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revival.Books.Services
{
    public class BookService : IBookService
    {
        private readonly RevivalBooksDbContext _db;
        
        public BookService(RevivalBooksDbContext db)
        {
            _db = db;
        }
            
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return  await _db.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int bookId)
        {
            var book =  await _db.Books.FindAsync(bookId); 
            if(book is null)
            {
                throw new BookIsNotExistsException($"Book with the given id isn't exists! Crushed here: {nameof(GetBook)}");
            }

            return book;
        }
        public async Task AddBook(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var bookToDelete = await _db.Books.FindAsync(bookId);
            
            if(bookToDelete is null)
            {
                throw new BookIsNotExistsException($"Book with the given id isn't exists! Crushed here: {nameof(DeleteBook)}");
            }

            _db.Books.Remove(bookToDelete);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateBook(int bookId, Book newBook)
        {
            var bookToUpdate = await _db.Books.FindAsync(bookId);
            
            if(bookToUpdate is null)
            {
                throw new BookIsNotExistsException($"Book with the given id isn't exists! Crushed here: {nameof(UpdateBook)}");
            }

            bookToUpdate = newBook;
            
            _db.Books.Update(bookToUpdate);
            await _db.SaveChangesAsync();
        }
    }
}
