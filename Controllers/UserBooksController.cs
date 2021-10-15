using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;
using BiblioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
  // Marks class as an API controller and adds default functionality
  [ApiController]
  [Route("rest-api/user-books")]
  public class UserBooksController : ControllerBase
  {
    private readonly IUserBooksService _userBooksService;
    private readonly IMapper _mapper;

    public UserBooksController(
            IUserBooksService userBooksService,
            IMapper mapper
        )
    {
      _userBooksService = userBooksService;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserBookDto>> GetUserBooks()
    {
      var userBookDtos = _userBooksService.GetUserBooks().Select(ub =>
          _mapper.Map<UserBookDto>(ub)
      );
      return Ok(userBookDtos);
    }

    [HttpGet("{id}", Name = "GetUserBook")]
    public ActionResult<UserBookDto> GetUserBook(Guid id)
    {
      var existingUserBook = _userBooksService.GetUserBookById(id);
      if (existingUserBook is null)
      {
        return NotFound();
      }

      var userBookDto = _mapper.Map<UserBookDto>(existingUserBook);
      return Ok(userBookDto);
    }

    // POST /users
    [HttpPost]
    public ActionResult<UserBookDto> CreateUserBook(CreateUserBookDto createUserBookDto)
    {
      var newUserBookModel = _mapper.Map<UserBook>(createUserBookDto);
      var newUserBook = _userBooksService.CreateUserBook(newUserBookModel);
      var newUserBookDto = _mapper.Map<UserBookDto>(newUserBook);

      return CreatedAtRoute(
          nameof(GetUserBook),
          new { Id = newUserBookDto.Id },
          newUserBookDto
      );
    }

    // PUT /items/{id}
    [HttpPut("{id}")]
    public ActionResult<UserBookDto> UpdateUserBook(Guid id, UpdateUserBookDto updateUserBookDto)
    {
      var existingUserBook = _userBooksService.GetUserBookById(id);

      if (existingUserBook is null)
      {
        return NotFound();
      }

      var updatedUserBook = _mapper.Map(updateUserBookDto, existingUserBook);
      _userBooksService.UpdateUserBook(updatedUserBook);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUserBook(Guid id)
    {
      var existingUserBook = _userBooksService.GetUserBookById(id);
      if (existingUserBook is null)
      {
        return NotFound();
      }
      _userBooksService.DeleteUserBook(existingUserBook);
      return NoContent();
    }

  }
}