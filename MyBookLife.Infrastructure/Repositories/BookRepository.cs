using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models.NoteBased;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context)
        {
            _context = context;
        }
        public int AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public IQueryable<Book> GetAllBooks()
        {
            var books = _context.Books;
            return books;
        }

        public Book GetBook(int bookId)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == bookId);
            return book;
        }

        public void RemoveBookById(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public void UpdateDiary(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).Property("Title").IsModified = true;
            _context.Entry(book).Property("Author").IsModified = true;
            _context.Entry(book).Property("TotalPages").IsModified = true;
            _context.SaveChanges();
        }
    }
}
