using System;
using System.Collections.Generic;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
    public interface IBooksRepository
    {
        Book GetBookById(Guid id);
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> CreateBook(Book book);
        Book UpdateBook(Book book);
        void DeleteBook(Guid id);
    }
}