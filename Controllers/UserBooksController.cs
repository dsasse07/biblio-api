using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Dtos.User;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;
using BiblioApi.Extensions;
using BiblioApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
    // Marks class as an API controller and adds default functionality
    [ApiController]
    [Route("user-books")]
    public class UserBooksController : ControllerBase
    {
        private readonly IUserBooksRepository _userBooksRepository;

        public UserBooksController(
            IUserBooksRepository userBooksRepository
        )
        {
            _userBooksRepository = userBooksRepository;
        }

        // POST /users
        [HttpPost]
        public ActionResult<UserDto> CreateUserBook(CreateUserBookDto createUserBookDto)
        {
            UserBook userBook = new()
            {
                Id = Guid.NewGuid(),
                UserId = createUserBookDto.UserId,
                BookId = createUserBookDto.BookId,
                CreatedAt = DateTimeOffset.UtcNow
            };

            var newUserBook = _userBooksRepository.CreateUserBook(userBook);

            return Ok(newUserBook.ToUserBookDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult<UserBookDto> UpdateUser(Guid id, UpdateUserBookDto updateUserBookDto){
            var existingUserBook = _userBooksRepository.GetUserBookById(id);

            if (existingUserBook is null){
                return NotFound();
            }

            UserBook updatedUserBook = existingUserBook with {
                IsActive = updateUserBookDto.IsActive,
            };

            var updatedUserBookDto = _userBooksRepository.UpdateUserBook(updatedUserBook).ToUserBookDto();

            return updatedUserBookDto;
        }

    }
}