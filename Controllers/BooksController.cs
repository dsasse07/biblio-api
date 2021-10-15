using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BiblioApi.Dtos.Book;
using BiblioApi.Entities;
using BiblioApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
  // Marks class as an API controller and adds default functionality
  [ApiController]
  [Route("rest-api/books")]
  public class BooksController : ControllerBase
  {
    private readonly IBooksService _booksService;
    private readonly IMapper _mapper;

    public BooksController(
        IBooksService booksService,
        IMapper mapper
    )
    {
      _booksService = booksService;
      _mapper = mapper;
    }

    // GET /books
    [HttpGet]
    public ActionResult<IEnumerable<BookDto>> GetBooks()
    {
      var books = _booksService.GetBooks().Select(book => _mapper.Map<BookDto>(book));
      return Ok(books);
    }

    // GET /books/{id}
    [HttpGet("{id}", Name = "GetBook")]
    public ActionResult<BookDto> GetBook(Guid id)
    {
      var book = _booksService.GetBookById(id);

      if (book is null)
      {
        return NotFound();
      }

      var bookDto = _mapper.Map<BookDto>(book);
      return Ok(bookDto);
    }

    // POST /books
    [HttpPost]
    public ActionResult<BookDto> CreateBook(CreateBookDto createBookDto)
    {
      // Maps from a createDto model to a NEW instance of <Type>
      var newBookModel = _mapper.Map<Book>(createBookDto);
      var newBook = _booksService.CreateBook(newBookModel);
      var newBookDto = _mapper.Map<BookDto>(newBook);

      return CreatedAtRoute(
              nameof(GetBook),
              new { Id = newBookDto.Id },
              newBookDto
          );
    }

    // PUT /items/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateBook(Guid id, UpdateBookDto updateBookDto)
    {
      var existingBook = _booksService.GetBookById(id);

      if (existingBook is null)
      {
        return NotFound();
      }

      // Maps from Source -> existing instance of target
      // Technically this mapping already updates our instance, just need to save it.
      var updatedBook = _mapper.Map(updateBookDto, existingBook);
      _booksService.UpdateBook(updatedBook);

      return NoContent();
    }

    // A PATCH request is a JSON Array of [{op, path, value}] that are performed on a record
    // If any of the ops fail, the whole request fails
    // Add, Remove, Replace, Copy, Move, Test
    // PATCH /books/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialUpdateBook(Guid id, JsonPatchDocument<UpdateBookDto> patchDocument)
    {
      var existingBook = _booksService.GetBookById(id);

      if (existingBook is null)
      {
        return NotFound();
      }

      // Create the full updateDto from the existing model.
      var updateBookDto = _mapper.Map<UpdateBookDto>(existingBook);
      // Apply PATCH operations
      patchDocument.ApplyTo(updateBookDto, ModelState);

      // Check if the model remains valid after the PATCH operations
      if (!TryValidateModel(updateBookDto))
      {
        return ValidationProblem(ModelState);
      }

      // Update the existing model with the updated DTO model
      var patchedBook = _mapper.Map(updateBookDto, existingBook);
      _booksService.UpdateBook(patchedBook);

      return NoContent();
    }

    // DELETE /books/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteBook(Guid id)
    {
      var existingBook = _booksService.GetBookById(id);

      if (existingBook is null)
      {
        return NotFound();
      }

      _booksService.DeleteBook(existingBook);

      return NoContent();
    }

  }
}