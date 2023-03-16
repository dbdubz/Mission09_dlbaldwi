using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_dlbaldwi.Models;

namespace Mission09_dlbaldwi.Pages
{
    public class OrderConfirmationModel : PageModel
    {        
        private ICheckoutRepo repo { get; set; }

        public OrderConfirmationModel(ICheckoutRepo temp, Purchases p)
        {
            repo = temp;
            Purchase = p;
        }
        public Purchases Purchase { get; set; }
        public void OnGet()
        {
            
        }
    }
}
