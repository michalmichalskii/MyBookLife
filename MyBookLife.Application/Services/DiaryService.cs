using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.ViewModels.DiaryVm;
using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Domain.Models.NotesBased;
using MyBookLife.Web.Models;
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
        private readonly IBookRepository _bookRepository;

        public DiaryService(IMapper mapper, IDiaryRepository diaryRepository, IEntryRepository entryRepository, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _diaryRepository = diaryRepository;
            _entryRepository = entryRepository;
            _bookRepository = bookRepository;
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

        public int AddTotalReadBooks(int diaryId, int booksRead)
        {
            var diaryVm = _diaryRepository.GetDiary(diaryId);
            diaryVm.TotalBooksRead += booksRead;
            var diary = _mapper.Map<Diary>(diaryVm);
            _diaryRepository.UpdateDiary(diary);
            return booksRead;
        }

        public int AddTotalReadPages(int diaryId, int pagesRead)
        {
            var diaryVm = _diaryRepository.GetDiary(diaryId);
            diaryVm.TotalPagesRead += pagesRead;
            var diary = _mapper.Map<Diary>(diaryVm);
            _diaryRepository.UpdateDiary(diary);
            return pagesRead;
        }

        public int SubstractTotalReadPages(int diaryId, int pagesRead)
        {
            var diaryVm = _diaryRepository.GetDiary(diaryId);
            diaryVm.TotalPagesRead -= pagesRead;
            var diary = _mapper.Map<Diary>(diaryVm);
            _diaryRepository.UpdateDiary(diary);
            return pagesRead;
        }

        public int SubstractTotalReadBooks(int diaryId, int minusBook)
        {
            var diaryVm = _diaryRepository.GetDiary(diaryId);
            diaryVm.TotalBooksRead -= minusBook;
            var diary = _mapper.Map<Diary>(diaryVm);
            _diaryRepository.UpdateDiary(diary);
            return minusBook;
        }
    }
}
