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
        private BookRepoInt repo { get; set; }
        public CartModel(BookRepoInt temp)
        {
            repo = temp;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            Cart = HttpContext.Session.GetJSON<Cart>("cart") ?? new Cart();
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(Book book, string returnUrl)
        {
            Book Book = repo.Books.FirstOrDefault(b => b.BookId == book.BookId);

            Cart = HttpContext.Session.GetJSON<Cart>("cart") ?? new Cart();
            Cart.AddBook(Book, 1);

            HttpContext.Session.SetJSON("cart", Cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
