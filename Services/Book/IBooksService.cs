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
        Book CreateBook(CreateBookDto createBookDto);
        Book UpdateBook(Book existingBook, UpdateBookDto updateBookDto);
        void DeleteBook(Guid id);
    }
}