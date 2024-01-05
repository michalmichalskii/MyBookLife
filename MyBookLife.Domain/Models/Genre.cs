namespace MyBookLife.Domain.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public virtual IEnumerable<BookGenre>? BookGenres { get; set; }
    }
}