using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Domain.Interfaces
{
    public interface IBookRepository
    {
        int AddBook(Book book);
        IQueryable<Book> GetAllBooks();
        Book GetBook(int bookId);
        void RemoveBookById(int bookId);
        void UpdateBook(Book book);
    }
}
