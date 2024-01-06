using AutoMapper;
using MyBookLife.Application.Mapping;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Domain.Models.NotesBased;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.ViewModels.EntryVm
{
    public class EntryForListVm : IMapFrom<Entry>
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int PagesRead { get; set; }
        public int TotalBooksRead { get; set; }
        public int DiaryId { get; set; }
        public string Book { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entry, EntryForListVm>()
                .ForMember(s => s.Book, opt => opt.MapFrom(d => d.Book.Title));
        }
    }
}
