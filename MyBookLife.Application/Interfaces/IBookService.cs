﻿using MyBookLife.Application.ViewModels.BookVm;
using MyBookLife.Application.ViewModels.DiaryVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.Interfaces
{
    public interface IBookService
    {
        int AddBook(NewBookVm newBookVm);
        int SubstractReadPages(int bookId, int pagesRead);
        NewBookVm GetBookForEdit(int bookId);
        List<BookForListVm> GetUserBooksList(string userId);
        void RemoveBookById(int bookId);
        void UpdateBook(NewBookVm bookVm);
        int AddReadPages(int bookId, int pagesRead);
    }
}
