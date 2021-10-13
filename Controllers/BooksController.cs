using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Dtos;
using BiblioApi.Dtos.Book;
using BiblioApi.Entities;
using BiblioApi.Extensions;
using BiblioApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
    // Marks class as an API controller and adds default functionality
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(
            IBooksRepository booksRepository
        )
        {
            _booksRepository = booksRepository;
        }

        // GET /books
        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            var books = _booksRepository.GetBooks().Select(book => book.ToBookDto());
            return books;
        }

        // GET /books/{id}
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(Guid id)
        {
            var book = _booksRepository.GetBookById(id);

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
            Book book = new()
            {
                Id = Guid.NewGuid(),
                VolumeId = createBookDto.VolumeId,
                Title = createBookDto.Title,
                Subtitle = createBookDto.Subtitle,
                Author = createBookDto.Author,
                PreviewImage = createBookDto.PreviewImage,
                PageCount = createBookDto.PageCount,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _booksRepository.CreateBook(book);

            return CreatedAtAction(
                    nameof(GetBook),
                    new { id = book.Id },
                    book.ToBookDto()
                );
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult<BookDto> UpdateBook(Guid id, UpdateBookDto updateBookDto){
            var existingBook = _booksRepository.GetBookById(id);

            if (existingBook is null){
                return NotFound();
            }

            Book updatedBook = existingBook with {
                VolumeId = updateBookDto.VolumeId,
                Title = updateBookDto.Title,
                Subtitle = updateBookDto.Subtitle,
                Author = updateBookDto.Author,
                PreviewImage = updateBookDto.PreviewImage,
                PageCount = updateBookDto.PageCount,
            };

            var updatedBookDto = _booksRepository.UpdateBook(updatedBook).ToBookDto();

            return updatedBookDto;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id){
            var existingBook = _booksRepository.GetBookById(id);

            if (existingBook is null){
                return NotFound();
            }

            _booksRepository.DeleteBook(id);

            return NoContent();
        }

    }
}