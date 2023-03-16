using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_dlbaldwi.Infrastructure;
using Mission09_dlbaldwi.Models;

namespace Mission09_dlbaldwi.Pages
{
    public class CartModel : PageModel
    {
        private IBookRepo repo { get; set; }
        public CartModel(IBookRepo temp, Cart c)
        {
            repo = temp;
            Cart = c;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(Book book, string returnUrl)
        {
            Book Book = repo.Books.FirstOrDefault(b => b.BookId == book.BookId);

            Cart.AddBook(Book, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            Cart.RemoveBook(Cart.Books.First(b => b.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
