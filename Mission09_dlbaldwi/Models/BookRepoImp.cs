using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Models
{
    public class BookRepoImp : BookRepoInt
    {
        private BookstoreContext context { get; set; }
        public BookRepoImp(BookstoreContext c) => context = c;
        public IQueryable<Book> Books => context.Books;
    }
}
