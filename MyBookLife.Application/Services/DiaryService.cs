using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models.NotesBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.Services
{
    public class DiaryService : IDiaryService
    {
        private readonly IMapper _mapper;
        private readonly IDiaryRepository _diaryRepository;
        private readonly IEntryRepository _entryRepository;

        public DiaryService(IMapper mapper, IDiaryRepository diaryRepository, IEntryRepository entryRepository)
        {
            _mapper = mapper;
            _diaryRepository = diaryRepository;
            _entryRepository = entryRepository;
        }

        public int AddDiary(NewDiaryVm newDiaryVm)
        {
            newDiaryVm.CreateDateTime = DateTime.Now;
            newDiaryVm.TotalPagesRead = 0;
            newDiaryVm.TotalBooksRead = 0;
            var diary = _mapper.Map<Diary>(newDiaryVm);
            var id = _diaryRepository.AddDiary(diary);
            return id;
        }

        public NewDiaryVm GetDiaryForEdit(int diaryId)
        {
            var diary = _diaryRepository.GetDiary(diaryId);
            var diaryVm = _mapper.Map<NewDiaryVm>(diary);
            return diaryVm;
        }

        public List<DiaryForListVm> GetUserDiariesList(string userId)
        {
            var diariesVm = _diaryRepository.GetAllDiaries()
                                          .Where(p => p.Owner == userId)
                                          .ProjectTo<DiaryForListVm>(_mapper.ConfigurationProvider)
                                          .ToList();

            return diariesVm;
        }

        public void RemoveDiaryById(int diaryId)
        {
            _diaryRepository.RemoveDiaryById(diaryId);
        }

        public void UpdateDiary(NewDiaryVm diaryVm)
        {
            var diary = _mapper.Map<Diary>(diaryVm);
            _diaryRepository.UpdateDiary(diary);
        }

        public void UpdateTotalBooks(DiaryForListVm diaryForListVm)
        {
            var totalBooks = 0;
            var allDiaryEntries = _entryRepository.GetAllEntries().Where(p => p.DiaryId == diaryForListVm.Id).ToList();
            foreach (var entry in allDiaryEntries)
            {
                totalBooks += entry.TotalBooksRead;
            }
            diaryForListVm.TotalPagesRead = totalBooks;
        }

        public void UpdateTotalPages(DiaryForListVm diaryForListVm)
        {
            var totalPages = 0;
            var allDiaryEntries = _entryRepository.GetAllEntries().Where(p => p.DiaryId == diaryForListVm.Id).ToList();
            foreach (var entry in allDiaryEntries)
            {
                totalPages += entry.TotalPagesRead;
            }
            diaryForListVm.TotalPagesRead = totalPages;
        }
    }
}
