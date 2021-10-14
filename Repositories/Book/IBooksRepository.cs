using System;
using System.Collections.Generic;
using BiblioApi.Dtos.Book;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
    public interface IBooksRepository
    {
        Book GetBookById(Guid id);
        IEnumerable<Book> GetBooks();
        Book CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        bool SaveChanges();
    }
}