using Microsoft.AspNetCore.Mvc;
using Mission09_dlbaldwi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private BookRepoInt repo { get; set; }

        public CategoriesViewComponent(BookRepoInt temp) => repo = temp;

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            var categories = repo.Books
                .Select(c => c.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
