using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.Services;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Application.ViewModels.EntryVm;
using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Domain.Models.NotesBased;

namespace MyBookLife.Web.Controllers
{
    [Authorize]
    public class DiaryController : Controller
    {
        private readonly IDiaryService _diaryService;
        private readonly IEntryService _entryService;
        private readonly IBookService _bookService;

        public DiaryController(IDiaryService diaryService, IEntryService entryService, IBookService bookService)
        {
            _diaryService = diaryService;
            _entryService = entryService;
            _bookService = bookService;
        }

        #region diary
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
            newDiaryVm.Owner = User.Identity.Name;
            var id = _diaryService.AddDiary(newDiaryVm);
            return RedirectToAction("Index");
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
        #endregion

        #region entries
        [HttpGet]
        public IActionResult DiaryEntries(int diaryId)
        {
            var entriesInDiary = _entryService.GetEntriesByDiaryId(diaryId);
            ViewBag.DiaryId = diaryId;

            return View(entriesInDiary);
        }

        [HttpGet]
        public IActionResult AddEntry(int diaryId)
        {
            var books = _bookService.GetUserBooksList(User.Identity.Name).Where(p => p.Read == false);

            ViewBag.Books = books;
            return View(new NewEntryVm()
            {
                DiaryId = diaryId
            });
        }

        [HttpPost]
        public IActionResult AddEntry(NewEntryVm newEntryVm)
        {
            newEntryVm.Owner = User.Identity.Name;

            var id = _entryService.AddEntry(newEntryVm);
            int booksRead = _bookService.AddReadPages(newEntryVm.BookId, newEntryVm.PagesRead);
            int totalDiaryReadPages = _diaryService.AddTotalReadPages(newEntryVm.DiaryId, newEntryVm.PagesRead);
            int totalBooksRead = _diaryService.AddTotalReadBooks(newEntryVm.DiaryId, booksRead);

            return RedirectToAction("DiaryEntries", new { diaryId = newEntryVm.DiaryId });
        }

        [HttpGet]
        public IActionResult EditEntry(int entryId)
        {
            var entry = _entryService.GetEntryForEdit(entryId);
            return View(entry);
        }

        [HttpPost]
        public IActionResult EditEntry(NewEntryVm entryVm)
        {
            _entryService.UpdateEntry(entryVm);
            return RedirectToAction("DiaryEntries", new { diaryId = entryVm.DiaryId });
        }

        [HttpGet]
        public IActionResult RemoveEntryById(int entryId)
        {
            var tmpEntry = _entryService.GetEntryForEdit(entryId);
            _entryService.RemoveEntryById(entryId);

            int minusBook = _bookService.SubstractReadPages(tmpEntry.BookId, tmpEntry.PagesRead);
            int totalDiaryReadPages = _diaryService.SubstractTotalReadPages(tmpEntry.DiaryId, tmpEntry.PagesRead);
            int totalBooksRead = _diaryService.SubstractTotalReadBooks(tmpEntry.DiaryId, minusBook);

            return RedirectToAction("DiaryEntries", new { diaryId = tmpEntry.DiaryId });
        }
        #endregion
    }
}
