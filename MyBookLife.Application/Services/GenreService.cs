using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.ViewModels.BookVm;
using MyBookLife.Application.ViewModels.GenreVm;
using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GenreService(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }
        public int AddGenre(NewGenreVm newGenreVm)
        {
            var genre = _mapper.Map<Genre>(newGenreVm);
            var id = _genreRepository.AddGenre(genre);
            return id;
        }

        public List<GenreForListVm> GetUserGenresList(string userId)
        {
            var genresVm = _genreRepository.GetAllGenres()
                                          .Where(p => p.Owner == userId)
                                          .ProjectTo<GenreForListVm>(_mapper.ConfigurationProvider)
                                          .ToList();

            return genresVm;
        }

        public void RemoveGenreById(int genreId)
        {
            _genreRepository.RemoveGenreById(genreId);
        }
    }
}
