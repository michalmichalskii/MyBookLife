using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.ViewModels.BookVm;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Application.ViewModels.EntryVm;
using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Domain.Models.NotesBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.Services
{
    public class EntryService : IEntryService
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;

        public EntryService(IMapper mapper, IEntryRepository entryRepository, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
        }

        public void UpdateBooksReadPages(BookForListVm bookForListVm)
        {
            var totalPages = 0;
            var allDiaryEntries = _entryRepository.GetAllEntries().Where(p => p.BookId == bookForListVm.Id).ToList();
            foreach (var entry in allDiaryEntries)
            {
                totalPages += entry.PagesRead;
            }
            bookForListVm.ReadPages = totalPages;
        }

        public int AddEntry(NewEntryVm newEntryVm)
        {
            newEntryVm.CreateDateTime = DateTime.Now;
            var entry = _mapper.Map<Entry>(newEntryVm);

            var id = _entryRepository.AddEntry(entry);

            return id;
        }

        public List<EntryForListVm> GetEntriesByDiaryId(int diaryId)
        {
            var entriesVm = _entryRepository.GetAllEntries()
                                            .Where(p => p.DiaryId == diaryId)
                                            .ProjectTo<EntryForListVm>(_mapper.ConfigurationProvider)
                                            .ToList();
            return entriesVm;
        }

        public NewEntryVm GetEntryForEdit(int entryId)
        {
            var entry = _entryRepository.GetEntry(entryId);
            var entryVm = _mapper.Map<NewEntryVm>(entry);
            return entryVm;
        }

        public void RemoveEntryById(int entryId)
        {
            _entryRepository.RemoveEntryById(entryId);
        }

        public void UpdateEntry(NewEntryVm entryVm)
        {
            var entry = _mapper.Map<Entry>(entryVm);
            _entryRepository.UpdateEntry(entry);
        }
    }
}
