using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Models
{
    public interface ICheckoutRepo
    {
        IQueryable<Checkout> Purchases { get; }

        void SavePurchase(Checkout checkout) {}
    }
}
