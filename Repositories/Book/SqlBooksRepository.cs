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
        private readonly DataContext DbContext;
        public SqlBooksRepository(
            DataContext context
            )
        {
            DbContext = context;
        }
        public IEnumerable<Book> GetBooks()
        {
            return DbContext.Books.ToList();
        }
        public Book GetBookById(Guid id)
        {
            return DbContext.Books.FirstOrDefault(book => book.Id == id);
        }

        public Book CreateBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            DbContext.Add(book);
            SaveChanges();
            return book;
        }
        public void UpdateBook(Book book)
        {
            SaveChanges();
        }

        public void DeleteBook(Book existingBook)
        {
            if (existingBook is null){
                throw new ArgumentNullException(nameof(existingBook));
            }

            DbContext.Books.Remove(existingBook);
            SaveChanges();
        }


        public bool SaveChanges()
        {
            return DbContext.SaveChanges() >= 0;
        }

    }
}