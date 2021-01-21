using System;

namespace Revival.Books.Services.Helpers.Exceptions
{
    public class BookIsNotExistsException : Exception
    {
        public BookIsNotExistsException() { }
        public BookIsNotExistsException(string message)
            : base(message) {  }
        
        public BookIsNotExistsException(string message, Exception inner)
            : base(message, inner) { }
    }
}
