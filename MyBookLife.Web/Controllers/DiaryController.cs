using Microsoft.AspNetCore.Mvc;
using MyBookLife.Application.Interfaces;

namespace MyBookLife.Web.Controllers
{
    public class DiaryController : Controller
    {
        private readonly IDiaryService _diaryService;
        private readonly IEntryService _entryService;
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;

        public DiaryController(IDiaryService diaryService, IEntryService entryService, IBookService bookService, IGenreService genreService)
        {
            _diaryService = diaryService;
            _entryService = entryService;
            _bookService = bookService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var diaries = _diaryService.GetUserDiariesList(User.Identity.Name);
            return View(diaries);
        }
    }
}
