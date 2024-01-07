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
        NewDiaryVm GetDiaryForEdit(int diaryId);
        void UpdateDiary(NewDiaryVm diaryVm);
        int AddTotalReadPages(int diaryId, int pagesRead);
        int AddTotalReadBooks(int diaryId, int booksRead);
        int SubstractTotalReadPages(int diaryId, int pagesRead);
        int SubstractTotalReadBooks(int diaryId, int minusBook);
    }
}
