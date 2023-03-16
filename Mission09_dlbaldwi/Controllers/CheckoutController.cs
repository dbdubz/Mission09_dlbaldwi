using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_dlbaldwi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepo _repo { get; set; }
        private Cart cart { get; set; }
        private Purchases purchase { get; set; }

        public CheckoutController(ICheckoutRepo repo, Cart c, Purchases p)
        {
            _repo = repo;
            cart = c;
            purchase = p;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }
        [HttpPost]
        public IActionResult Checkout(Checkout checkout)
        {
            if (cart.Books.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is invalid!");
            }
            
            if (ModelState.IsValid)
            {
                checkout.Lines = cart.Books.ToArray();
                _repo.SavePurchase(checkout);
                purchase.AddPurchase(checkout);
                cart.ClearCart();
                return RedirectToPage("/OrderConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
