using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Domain.Models.NotesBased;

namespace MyBookLife.Web.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult Index()
        {
            var diaries = _diaryService.GetUserDiariesList(User.Identity.Name);
            return View(diaries);
        }

        [HttpGet]
        public IActionResult AddDiary()
        {
            return View(new NewDiaryVm());
        }
        [HttpPost]
        public IActionResult AddDiary(NewDiaryVm newDiaryVm)
        {
            if (ModelState.IsValid)
            {
                newDiaryVm.Owner = User.Identity.Name;
                var id = _diaryService.AddDiary(newDiaryVm);
                return RedirectToAction("Index");
            }
            return View(newDiaryVm);
        }

        [HttpGet]
        public IActionResult EditDiary(int diaryId)
        {
            var diary = _diaryService.GetDiaryForEdit(diaryId);
            return View(diary);
        }
        [HttpPost]
        public IActionResult EditDiary(NewDiaryVm diaryVm)
        {
            if (ModelState.IsValid)
            {
                _diaryService.UpdateDiary(diaryVm);
                return RedirectToAction("Index");
            }
            return View(diaryVm);
        }

        [HttpGet]
        public IActionResult RemoveDiaryById(int diaryId)
        {
            _diaryService.RemoveDiaryById(diaryId);
            return RedirectToAction("Index");
        }
    }
}
