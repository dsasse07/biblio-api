using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;
using BiblioApi.Extensions;
using BiblioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
    // Marks class as an API controller and adds default functionality
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(
            IUsersService usersService
        )
        {
            _usersService = usersService;
        }

        // GET /users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var users = _usersService.GetUsers().Select(user => user.ToUserDto());
            return Ok(users);
        }

        // GET /users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(Guid id)
        {
            var book = _usersService.GetUserById(id);

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
            var newUser = _usersService.CreateUser(createUserDto);

            return CreatedAtAction(
                    nameof(GetUser),
                    new { id = newUser.Id },
                    newUser.ToUserDto()
                );
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult<UserDto> UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var existingUser = _usersService.GetUserById(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            var updatedUserDto = _usersService.UpdateUser(existingUser, updateUserDto).ToUserDto();

            return updatedUserDto;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            var existingUser = _usersService.GetUserById(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            _usersService.DeleteUser(id);

            return NoContent();
        }

    }
}