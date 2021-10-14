using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Dtos;
using BiblioApi.Dtos.Book;
using BiblioApi.Entities;
using BiblioApi.Extensions;
using BiblioApi.Repositories;
using BiblioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
    // Marks class as an API controller and adds default functionality
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(
            IBooksService booksService
        )
        {
            _booksService = booksService;
        }

        // GET /books
        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            var books = _booksService.GetBooks().Select(book => book.ToBookDto());
            return books;
        }

        // GET /books/{id}
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(Guid id)
        {
            var book = _booksService.GetBookById(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book.ToBookDto());
        }

        // POST /books
        [HttpPost]
        public ActionResult<BookDto> CreateBook(CreateBookDto createBookDto)
        {
            var newBook = _booksService.CreateBook(createBookDto);

            return CreatedAtAction(
                    nameof(GetBook),
                    new { id = newBook.Id },
                    newBook.ToBookDto()
                );
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult<BookDto> UpdateBook(Guid id, UpdateBookDto updateBookDto)
        {
            var existingBook = _booksService.GetBookById(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            var updatedBookDto = _booksService.UpdateBook(existingBook, updateBookDto).ToBookDto();

            return updatedBookDto;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var existingBook = _booksService.GetBookById(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            _booksService.DeleteBook(id);

            return NoContent();
        }

    }
}