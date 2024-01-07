using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.ViewModels.StatVm;

namespace MyBookLife.Web.Controllers
{
    [Authorize]
    public class WrappedController : Controller
    {
        private readonly IEntryService _entryService;
        private readonly IBookService _bookService;

        public WrappedController(IEntryService entryService, IBookService bookService)
        {
            _entryService = entryService;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _bookService.GetUserBooksList(User.Identity.Name);
            var entries = _entryService.GetAllUserEntries(User.Identity.Name);

            //favourite genre
            var listOfGenres = new List<string>();
            var groupedBooksByGenre = books.GroupBy(b => b.Genre);
            var mostPopularGenre = groupedBooksByGenre.OrderByDescending(group => group.Count()).FirstOrDefault();
            string favoriteGenre = mostPopularGenre?.FirstOrDefault()?.Genre ?? "Brak danych";

            //total pages read
            int totalPages = 0;
            foreach (var book in books)
            {
                totalPages += (int)book.ReadPages;
            }

            //Longest Book
            var readBooks = books.Where(p => p.Read == true);
            var groupedReadBooksByLength = readBooks.GroupBy(b => b.TotalPages);
            var sortedGroups = groupedReadBooksByLength.OrderByDescending(group => group.Key);
            var longestBookGroup = sortedGroups.FirstOrDefault();
            string longestBookTitle = "Brak danych";
            int longestBookPages = 0;
            if (longestBookGroup != null)
            {
                var longestBook = longestBookGroup.FirstOrDefault();
                if (longestBook != null)
                {
                    longestBookTitle = longestBook.Title;
                    longestBookPages = longestBook.TotalPages;
                }
            }

            //Shorest Book
            var sortedGroups2 = groupedReadBooksByLength.OrderBy(group => group.Key);
            var shortestBookGroup = sortedGroups2.FirstOrDefault();
            string shortestBookTitle = "Brak danych";
            int shortestBookPages = 0;
            if (shortestBookGroup != null)
            {
                var shortestBook = shortestBookGroup.FirstOrDefault();
                if (shortestBook != null)
                {
                    shortestBookTitle = shortestBook.Title;
                    shortestBookPages = shortestBook.TotalPages;
                }
            }

            //read books count
            var totalBooksReadCount = books.Where(p => p.Read == true).Count();

            int averageLengthOfReadBooks;
            if (totalBooksReadCount == 0)
                averageLengthOfReadBooks = 0;
            else
                averageLengthOfReadBooks = totalPages / totalBooksReadCount;

            var stats = new SatsForListVm()
            {
                //books count
                StartedBooks = books.Count,

                FavouriveGenre = favoriteGenre,
                TotalPagesRead = totalPages,

                LongestReadBookTitle = longestBookTitle,
                LongestReadBookPages = longestBookPages,

                ShortestReadBookTitle = shortestBookTitle,
                ShortestReadBookPages = shortestBookPages,

                TotalBooksRead = totalBooksReadCount,

                //Total number of entries
                TotalEntries = entries.Count,

                //AverageLengthOfReadBooks
                AverageLengthOfReadBooks = averageLengthOfReadBooks

            };

            var statsList = new List<SatsForListVm>();
            statsList.Add(stats);

            return View(statsList);
        }
    }
}
