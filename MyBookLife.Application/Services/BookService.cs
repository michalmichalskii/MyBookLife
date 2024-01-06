using AutoMapper;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.Mapping;
using MyBookLife.Application.ViewModels.BookVm;
using MyBookLife.Domain.Interfaces;
using MyBookLife.Domain.Models.NotesBased;
using MyBookLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookLife.Application.ViewModels.DiaryVm;
using AutoMapper.QueryableExtensions;

namespace MyBookLife.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public int AddBook(NewBookVm newBookVm)
        {
            var book = _mapper.Map<Book>(newBookVm);
            var id = _bookRepository.AddBook(book);
            return id;
        }

        public NewBookVm GetBookForEdit(int bookId)
        {
            var book = _bookRepository.GetBook(bookId);
            var bookVm = _mapper.Map<NewBookVm>(book);
            return bookVm;
        }

        public List<BookForListVm> GetUserBooksList(string userId)
        {
            var booksVm = _bookRepository.GetAllBooks()
                                          .Where(p => p.Owner == userId)
                                          .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider)
                                          .ToList();

            return booksVm;
        }

        public void RemoveBookById(int bookId)
        {
            _bookRepository.RemoveBookById(bookId);
        }

        public void UpdateBook(NewBookVm bookVm)
        {
            var book = _mapper.Map<Book>(bookVm);
            _bookRepository.UpdateDiary(book);
        }
    }
}
