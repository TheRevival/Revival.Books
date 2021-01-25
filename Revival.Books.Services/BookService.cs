using Microsoft.EntityFrameworkCore;
using Revival.Books.Data;
using Revival.Books.Data.Models;
using Revival.Books.Services.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revival.Books.Services
{
    public class BookService : IBookService
    {
        private readonly RevivalBooksDbContext _db;
        
        public BookService(RevivalBooksDbContext db)
            => (_db) = (db);
            
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetBookAsync(int bookId)
        {
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == bookId); 
            if(book is null)
            {
                throw new BookIsNotExistsException($"Book with the given id isn't exists! Crushed here: {nameof(GetBookAsync)}");
            }

            return book;
        }
        public async Task AddBookAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var bookToDelete = await _db.Books.FindAsync(bookId);
            
            if(bookToDelete is null)
            {
                throw new BookIsNotExistsException($"Book with the given id isn't exists! Crushed here: {nameof(DeleteBookAsync)}");
            }

            _db.Books.Remove(bookToDelete);
            await _db.SaveChangesAsync();
        }
    }
}
