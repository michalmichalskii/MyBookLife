using AutoMapper;
using MyBookLife.Application.Mapping;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Domain.Models.NotesBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.ViewModels.EntryVm
{
    public class EntryForListVm : IMapFrom<Entry>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int TotalPagesRead { get; set; }
        public int TotalBooksRead { get; set; }
        public virtual int DiaryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entry, EntryForListVm>();
        }
    }
}
