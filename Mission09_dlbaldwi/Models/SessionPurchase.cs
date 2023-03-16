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
    public class SessionPurchase : Purchases
    {
        [JsonIgnore] public ISession Session { get; set; }

        public static Purchases GetPurchase(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionPurchase Purchase = session?.GetJSON<SessionPurchase>("Purchase") ?? new SessionPurchase();
            Purchase.Session = session;
            return Purchase;
        }

        public override void AddPurchase(Checkout c)
        {
            base.AddPurchase(c);
            Session.SetJSON("Purchase", this);
        }
    }
}
