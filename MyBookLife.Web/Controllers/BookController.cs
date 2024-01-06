using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.Services;
using MyBookLife.Application.ViewModels.BookVm;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Application.ViewModels.GenreVm;

namespace MyBookLife.Web.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        public BookController(IBookService bookService, IGenreService genreService)
        {
            _bookService = bookService;
            _genreService = genreService;
        }

        #region book
        [HttpGet]
        public IActionResult Index()
        {
            var books = _bookService.GetUserBooksList(User.Identity.Name);

            return View(books);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            var genres = _genreService.GetUserGenresList(User.Identity.Name);
            ViewBag.Genres = genres;
            return View(new NewBookVm());
        }
        [HttpPost]
        public IActionResult AddBook(NewBookVm newBookVm)
        {
            newBookVm.Owner = User.Identity.Name;
            newBookVm.ReadPages = 0;
            var id = _bookService.AddBook(newBookVm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditBook(int bookId)
        {
            var book = _bookService.GetBookForEdit(bookId);
            return View(book);
        }
        [HttpPost]
        public IActionResult EditBook(NewBookVm bookVm)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(bookVm);
                return RedirectToAction("Index");
            }
            return View(bookVm);
        }

        [HttpGet]
        public IActionResult RemoveBookById(int bookId)
        {
            _bookService.RemoveBookById(bookId);
            return RedirectToAction("Index");
        }
        #endregion

        #region genres
        [HttpGet]
        public IActionResult GetListOfGenres()
        {
            var genres = _genreService.GetUserGenresList(User.Identity.Name);

            return View(genres);
        }

        [HttpGet]
        public IActionResult AddGenre()
        {
            return View(new NewGenreVm());
        }
        [HttpPost]
        public IActionResult AddGenre(NewGenreVm newGenreVm)
        {
            newGenreVm.Owner = User.Identity.Name;
            var id = _genreService.AddGenre(newGenreVm);
            return RedirectToAction("GetListOfGenres");
        }

        [HttpGet]
        public IActionResult RemoveGenreById(int genreId)
        {
            _genreService.RemoveGenreById(genreId);
            return RedirectToAction("GetListOfGenres");
        }
        #endregion
    }
}
