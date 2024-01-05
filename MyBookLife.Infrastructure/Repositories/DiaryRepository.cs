using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models.NotesBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Infrastructure.Repositories
{
    public class DiaryRepository : IDiaryRepository
    {
        private Context _context;

        public DiaryRepository(Context context)
        {
            _context = context;
        }

        IQueryable<Diary> IDiaryRepository.GetAllDiaries()
        {
            var diaries = _context.Diaries;
            return diaries;
        }

        public int AddDiary(Diary diary)
        {
            _context.Diaries.Add(diary);
            _context.SaveChanges();
            return diary.Id;
        }

        public void RemoveDiaryById(int diaryId)
        {
            var diary = _context.Diaries.Find(diaryId);
            if (diary != null)
            {
                _context.Diaries.Remove(diary);
                _context.SaveChanges() ;
            }
        }

        public Diary GetDiary(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDiary(int diaryId)
        {
            throw new NotImplementedException();
        }
    }
}
