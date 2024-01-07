using MyBookLife.Domain.Models.Notes;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Domain.Models.NoteBased
{
    public class Entry : Note
    {
        public int DiaryId { get; set; }
        public int BookId { get; set; }
        public int PagesRead { get; set; }
        public string Owner { get; set; }
        public virtual Book Book { get; set; }
    }
}
