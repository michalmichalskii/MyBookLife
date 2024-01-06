using MyBookLife.Domain.Models.NoteBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Domain.Interfaces
{
    public interface IEntryRepository
    {
        int AddEntry(Entry entry);
        IQueryable<Entry> GetAllEntries();
        Entry GetEntry(int entryId);
        void RemoveEntryById(int entryId);
        void UpdateEntry(Entry entry);
    }
}
