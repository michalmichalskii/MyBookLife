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

        public DiaryService(IMapper mapper, IDiaryRepository diaryRepository)
        {
            _mapper = mapper;
            _diaryRepository = diaryRepository;
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

        public List<DiaryForListVm> GetUserDiariesList(string userId)
        {
            var diaries = _diaryRepository.GetAllDiaries()
                                          .Where(p => p.Owner == userId)
                                          .ProjectTo<DiaryForListVm>(_mapper.ConfigurationProvider)
                                          .ToList();
            return diaries;
        }

        public void RemoveDiaryById(int diaryId)
        {
            _diaryRepository.RemoveDiaryById(diaryId);
        }
    }
}
