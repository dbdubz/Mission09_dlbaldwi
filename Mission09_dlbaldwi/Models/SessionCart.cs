using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission09_dlbaldwi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore] public ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart Cart = session?.GetJSON<SessionCart>("Cart") ?? new SessionCart();
            Cart.Session = session;
            return Cart;
        }

        public override void AddBook(Book book, int quantity)
        {
            base.AddBook(book, quantity);
            Session.SetJSON("Cart", this);
        }

        public override void RemoveBook(Book book)
        {
            base.RemoveBook(book);
            Session.SetJSON("Cart", this);
        }
        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}
