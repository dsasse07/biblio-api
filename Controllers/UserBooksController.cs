using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Dtos.User;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;
using BiblioApi.Extensions;
using BiblioApi.Repositories;
using BiblioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
    // Marks class as an API controller and adds default functionality
    [ApiController]
    [Route("user-books")]
    public class UserBooksController : ControllerBase
    {
        private readonly IUserBooksService _userBooksService;

        public UserBooksController(
            IUserBooksService userBooksService
        )
        {
            _userBooksService = userBooksService;
        }

        // POST /users
        [HttpPost]
        public ActionResult<UserBookDto> CreateUserBook(CreateUserBookDto createUserBookDto)
        {
            var newUserBook = _userBooksService.CreateUserBook(createUserBookDto);

            return Ok(newUserBook.ToUserBookDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult<UserBookDto> UpdateUser(Guid id, UpdateUserBookDto updateUserBookDto)
        {
            var existingUserBook = _userBooksService.GetUserBookById(id);

            if (existingUserBook is null)
            {
                return NotFound();
            }

            var updatedUserBookDto = _userBooksService.UpdateUserBook(existingUserBook, updateUserBookDto).ToUserBookDto();

            return updatedUserBookDto;
        }

    }
}