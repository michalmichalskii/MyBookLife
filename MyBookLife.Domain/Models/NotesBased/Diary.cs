using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Domain.Models.Notes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Domain.Models.NotesBased
{
    public class Diary : Note
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public int TotalPagesRead { get; set; }
        public int TotalBooksRead { get; set; }
        public virtual IEnumerable<Entry>? Entries { get; set; }
    }
}
