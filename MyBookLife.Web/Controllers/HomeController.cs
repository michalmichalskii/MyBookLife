using Microsoft.AspNetCore.Mvc;
using MyBookLife.Web.Models;
using System.Diagnostics;

namespace MyBookLife.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ShowListOfBooks()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Id = 1, Author = "Tolkien", TotalPages = 100, Title="hobbit" });
            books.Add(new Book { Id = 2, Author = "Masny Ben", TotalPages = 11, Title="YT" });
            books.Add(new Book { Id = 3, Author = "Xayoo", TotalPages = 1010, Title="twitch" });

            return View(books);
        }
    }
}
