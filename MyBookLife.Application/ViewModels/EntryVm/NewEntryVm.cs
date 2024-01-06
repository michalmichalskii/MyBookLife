using AutoMapper;
using MyBookLife.Application.Mapping;
using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.ViewModels.EntryVm
{
    public class NewEntryVm : IMapFrom<Entry>
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int TotalPagesRead { get; set; }
        public int TotalBooksRead { get; set; }
        public int DiaryId { get; set; }
        public int BookId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewEntryVm, Entry>().ReverseMap();
        }
    }
}
