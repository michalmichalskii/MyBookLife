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
        public virtual int DiaryId { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
