using MyBookLife.Domain.Models;
using MyBookLife.Domain.Models.NoteBased;

namespace MyBookLife.Web.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Author { get; set; }
        public int TotalPages { get; set; }
        public int? ReadPages { get; set; }
        public string Owner { get; set; }
        public virtual IEnumerable<Entry> Entries { get; set; }
        public virtual IEnumerable<BookGenre> BookGenres { get; set; }
    }
}
