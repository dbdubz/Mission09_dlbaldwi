using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrPage { get; set; }
        public int NumPages => (int)Math.Ceiling((decimal)TotalBooks / BooksPerPage);
    }
}
