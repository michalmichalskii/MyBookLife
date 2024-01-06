using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyBookLife.Application.Interfaces;
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
        private readonly IDiaryRepository _diaryRepository;

        public EntryService(IMapper mapper, IEntryRepository entryRepository, IDiaryRepository diaryRepository)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
            _diaryRepository = diaryRepository;
        }

        public int AddEntry(NewEntryVm newEntryVm)
        {
            newEntryVm.CreateDateTime = DateTime.Now;
            var entry = _mapper.Map<Entry>(newEntryVm);

            //var diary = _diaryRepository.GetDiary(entry.DiaryId);
            //diary.TotalPagesRead += entry.TotalPagesRead;
            //diary.TotalBooksRead += entry.TotalBooksRead;

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
