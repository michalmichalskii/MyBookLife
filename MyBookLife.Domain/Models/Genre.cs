using MyBookLife.Web.Models;

namespace MyBookLife.Domain.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public string Owner { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}