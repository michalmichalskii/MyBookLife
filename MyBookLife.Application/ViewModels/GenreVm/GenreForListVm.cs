using AutoMapper;
using MyBookLife.Application.Mapping;
using MyBookLife.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.ViewModels.GenreVm
{
    public class GenreForListVm : IMapFrom<Genre>
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public string Owner { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreForListVm>();
        }
    }
}
