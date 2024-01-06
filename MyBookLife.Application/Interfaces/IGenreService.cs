using MyBookLife.Application.ViewModels.GenreVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.Interfaces
{
    public interface IGenreService
    {
        int AddGenre(NewGenreVm newGenreVm);
        List<GenreForListVm> GetUserGenresList(string userId);
        void RemoveGenreById(int genreId);
    }
}
