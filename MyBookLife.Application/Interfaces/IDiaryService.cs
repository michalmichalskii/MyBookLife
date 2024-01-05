using MyBookLife.Application.ViewModels.DiaryVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.Interfaces
{
    public interface IDiaryService
    {
        List<DiaryForListVm> GetUserDiariesList(string userId);
        int AddDiary(NewDiaryVm newDiaryVm);
        void RemoveDiaryById(int diaryId);
    }
}
