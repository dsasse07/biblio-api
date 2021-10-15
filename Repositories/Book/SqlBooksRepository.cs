using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BiblioApi.Data;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
  public class SqlBooksRepository : IBooksRepository
  {
    private readonly DataContext _DbContext;
    public SqlBooksRepository(
        DataContext context
    )
    {
      _DbContext = context;
    }
    public IEnumerable<Book> GetBooks()
    {
      return _DbContext.Books.ToList();
    }
    public Book GetBookById(Guid id)
    {
      return _DbContext.Books.FirstOrDefault(book => book.Id == id);
    }

    public Book CreateBook(Book book)
    {
      if (book is null)
      {
        throw new ArgumentNullException(nameof(book));
      }

      _DbContext.Add(book);
      SaveChanges();
      return book;
    }
    public void UpdateBook(Book book)
    {
      SaveChanges();
    }

    public void DeleteBook(Book existingBook)
    {
      if (existingBook is null)
      {
        throw new ArgumentNullException(nameof(existingBook));
      }

      _DbContext.Books.Remove(existingBook);
      SaveChanges();
    }


    public bool SaveChanges()
    {
      return _DbContext.SaveChanges() >= 0;
    }

  }
}