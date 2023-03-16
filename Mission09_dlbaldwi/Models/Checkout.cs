using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Models
{
    public class Checkout
    {
        [Key][BindNever] public int PurchaseId { get; set; }
        [BindNever] public ICollection<LineItem> Lines { get; set; }
        [Required(ErrorMessage = "Please enter your name")] public string Name { get; set; }
        [Required(ErrorMessage = "Please enter address info")] public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Please enter your city")] public string City { get; set; }
        [Required(ErrorMessage = "Please enter your state")] public string State { get; set; }
        [Required(ErrorMessage = "Please enter zipcode")] public string Zipcode { get; set; }
        [Required(ErrorMessage = "Please enter your country")] public string Country { get; set; }
    }
}
