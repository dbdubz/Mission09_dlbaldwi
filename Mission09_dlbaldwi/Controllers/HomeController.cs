using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_dlbaldwi.Models;
using Mission09_dlbaldwi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BookRepoInt _repo;

        public HomeController(ILogger<HomeController> logger, BookRepoInt repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;
            var books = new BooksViewModel
            {
                Books = _repo.Books
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalBooks = _repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrPage = pageNum
                }
            };
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
