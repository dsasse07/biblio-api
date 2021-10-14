using System;
using System.Collections.Generic;
using BiblioApi.Dtos.Book;
using BiblioApi.Entities;

namespace BiblioApi.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(Guid id);
        Book CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book existingBook);
    }
}