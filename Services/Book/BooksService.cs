using System;
using System.Collections.Generic;
using BiblioApi.Dtos.Book;
using BiblioApi.Entities;
using BiblioApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BiblioApi.Services
{

    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _booksRepository.GetBooks();
        }

        public Book GetBookById(Guid id)
        {
            return _booksRepository.GetBookById(id);
        }

        public Book CreateBook(Book book)
        {            
            return _booksRepository.CreateBook(book);
        }

        public void UpdateBook(Book book)
        {
            _booksRepository.UpdateBook(book);
        }
        public void DeleteBook(Book existingBook)
        {
            _booksRepository.DeleteBook(existingBook);
        }
    }
}