using MyBookLife.Domain.Models.NotesBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Domain.Interfaces
{
    public interface IDiaryRepository
    {
        IQueryable<Diary> GetAllDiaries();
        Diary GetDiary(int id);
        int AddDiary(Diary diary);
        void RemoveDiaryById(int diaryId);
        void UpdateDiary(int diaryId);

    }
}
