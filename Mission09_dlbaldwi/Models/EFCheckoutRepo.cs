using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Models
{
    public class EFCheckoutRepo : ICheckoutRepo
    {
        private BookstoreContext context { get; set; }
        public EFCheckoutRepo(BookstoreContext c) => context = c;
        public IQueryable<Checkout> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(l => l.Book));

            if (checkout.PurchaseId == 0)
            {
                context.Purchases.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}
