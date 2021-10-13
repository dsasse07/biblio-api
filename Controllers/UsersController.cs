using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;
using BiblioApi.Extensions;
using BiblioApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
    // Marks class as an API controller and adds default functionality
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(
            IUsersRepository usersRepository
        )
        {
            _usersRepository = usersRepository;
        }

        // GET /users
        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = _usersRepository.GetUsers().Select(user => user.ToUserDto());
            return users;
        }

        // GET /users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(Guid id)
        {
            var book = _usersRepository.GetUserById(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book.ToUserDto());
        }

        // POST /users
        [HttpPost]
        public ActionResult<UserDto> CreateUser(CreateUserDto createUserDto)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _usersRepository.CreateUser(user);

            return CreatedAtAction(
                    nameof(GetUser),
                    new { id = user.Id },
                    user.ToUserDto()
                );
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult<UserDto> UpdateUser(Guid id, UpdateUserDto updateUserDto){
            var existingUser = _usersRepository.GetUserById(id);

            if (existingUser is null){
                return NotFound();
            }

            User updatedUser = existingUser with {
                FirstName = updateUserDto.FirstName,
                LastName = updateUserDto.LastName,
            };

            var updatedUserDto = _usersRepository.UpdateUser(updatedUser).ToUserDto();

            return updatedUserDto;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id){
            var existingUser = _usersRepository.GetUserById(id);

            if (existingUser is null){
                return NotFound();
            }

            _usersRepository.DeleteUser(id);

            return NoContent();
        }

    }
}