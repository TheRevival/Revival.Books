using System;
using System.Collections.Generic;

namespace Revival.Books.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Author Author { get; set; }
    }
}
