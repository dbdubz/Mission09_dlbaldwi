using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Models
{
    public class Cart
    {
        public List<LineItem> Books { get; set; } = new List<LineItem>();

        public void AddBook(Book book, int quantity)
        {
            LineItem line = Books
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Books.Add(new LineItem
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public double CalcTotal()
        {
            double total = Books.Sum(x => x.Quantity * x.Book.Price);
            return total;
        }
    }

    public class LineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
