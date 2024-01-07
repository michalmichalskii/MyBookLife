using AutoMapper;
using MyBookLife.Application.Mapping;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Domain.Models.NotesBased;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.ViewModels.BookVm
{
    public class BookForListVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Author { get; set; }
        public int TotalPages { get; set; }
        public int? ReadPages { get; set; }
        public string Owner { get; set; }
        public string Genre { get; set; }
        public bool Read { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookForListVm>()
                .ForMember(s => s.Genre, opt => opt.MapFrom(d => d.Genre.GenreName));
        }
    }
}
