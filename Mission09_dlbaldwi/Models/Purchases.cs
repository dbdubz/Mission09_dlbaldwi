using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Models
{
    public class Purchases
    {
        public List<Checkout> Checkouts { get; set; } = new List<Checkout>();

        public virtual void AddPurchase(Checkout c)
        {
            Checkouts.Add(c);
        }
    }
}
