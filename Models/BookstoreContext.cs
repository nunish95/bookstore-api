using System;
using Microsoft.EntityFrameworkCore;

namespace Fisher.Bookstore.Api.Models{
    
    public class BookstoreContext: DbContext{

        public BookstoreContext(DbContextOptions<BookstoreContext> options) 
             :base(options)
             {
             }
             public DbSet<Book> Books {get;set; }
             public DbSet<Author> Authors {get;set; }

        internal object GetBooks()
        {
            throw new NotImplementedException();
        }
        internal object GetAuthors()
        {
            throw new NotImplementedException();
        }
    }
}