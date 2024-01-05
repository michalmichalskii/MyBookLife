using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.ViewModels;
using MyBookLife.Domain.Interfaces;
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

        public List<DiaryForListVm> GetUserDiariesList(string userId)
        {
            var diaries = _diaryRepository.GetAllDiaries()
                                          .Where(p => p.Owner == userId)
                                          .ProjectTo<DiaryForListVm>(_mapper.ConfigurationProvider)
                                          .ToList();
            return diaries;
        }
    }
}
