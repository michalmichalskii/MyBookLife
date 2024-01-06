using Microsoft.EntityFrameworkCore;
using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Domain.Models.NotesBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Infrastructure.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly Context _context;

        public EntryRepository(Context context)
        {
            _context = context;
        }

        public int AddEntry(Entry entry)
        {
            _context.Entries.Add(entry);
            _context.SaveChanges();
            return entry.Id;
        }

        public IQueryable<Entry> GetAllEntries()
        {
            var entries = _context.Entries;
            return entries;
        }

        public Entry GetEntry(int entryId)
        {
            var entry = _context.Entries.FirstOrDefault(p => p.Id == entryId);
            return entry;
        }

        public void RemoveEntryById(int entryId)
        {
            var entry = _context.Entries.Find(entryId);
            if (entry != null)
            {
                _context.Entries.Remove(entry);
                _context.SaveChanges();
            }
        }

        public void UpdateEntry(Entry entry)
        {
            _context.Attach(entry);

            //TODO - title, not name

            /*_context.Entry(entry).Property("Name").IsModified = true;*/

            _context.Entry(entry).Property("TotalPagesRead").IsModified = true;
            _context.Entry(entry).Property("TotalBooksRead").IsModified = true;
            _context.SaveChanges();
        }
    }
}
