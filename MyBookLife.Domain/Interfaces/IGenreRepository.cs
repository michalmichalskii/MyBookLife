
using MyBookLife.Domain.Models;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Domain.Interfaces
{
    public interface IGenreRepository
    {
        int AddGenre(Genre genre);
        IQueryable<Genre> GetAllGenres();
        void RemoveGenreById(int genreId);
    }
}
