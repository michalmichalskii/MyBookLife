﻿using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models.NotesBased;
using MyBookLife.Infrastructure.Migrations;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Infrastructure.Repositories
{
    public class DiaryRepository : IDiaryRepository
    {
        private readonly Context _context;

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
            var diary = _context.Diaries.FirstOrDefault(p => p.Id == id);
            return diary;
        }

        public void UpdateDiary(Diary diary)
        {
            _context.Attach(diary);
            _context.Entry(diary).Property("Name").IsModified = true;
            _context.Entry(diary).Property("TotalPagesRead").IsModified = true;
            _context.Entry(diary).Property("TotalBooksRead").IsModified = true;
            _context.SaveChanges();
        }

        public int UpdatePagesRead(Diary diary, int totalPages)
        {
            _context.Attach(diary);
            diary.TotalPagesRead = totalPages;
            _context.SaveChanges();
            return totalPages;
        }
    }
}
