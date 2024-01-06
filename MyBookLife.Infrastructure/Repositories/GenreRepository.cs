using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly Context _context;

        public GenreRepository(Context context)
        {
            _context = context;
        }
        public int AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return genre.Id;
        }

        public IQueryable<Genre> GetAllGenres()
        {
            var genres = _context.Genres;
            return genres;
        }

        public void RemoveGenreById(int genreId)
        {
            var genre = _context.Genres.Find(genreId);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}
