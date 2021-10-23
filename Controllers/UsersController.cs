using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;
using BiblioApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{
  // Marks class as an API controller and adds default functionality
  [ApiController]
  [Route("rest-api/users")]
  public class UsersController : ControllerBase
  {
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;

    public UsersController(
            IUsersService usersService,
            IMapper mapper
        )
    {
      _usersService = usersService;
      _mapper = mapper;
    }

    // GET /users
    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetUsers()
    {
      var users = _usersService.GetUsers().Select(user =>
          _mapper.Map<UserDto>(user)
      );
      return Ok(users);
    }

    // GET /users/{id}
    [HttpGet("{id}")]
    public ActionResult<UserDto> GetUser(Guid id)
    {
      var user = _usersService.GetUserById(id);

      if (user is null)
      {
        return NotFound();
      }

      var userDto = _mapper.Map<UserDto>(user);
      return Ok(userDto);
    }

    // POST /users
    [HttpPost]
    public ActionResult<UserDto> CreateUser(CreateUserDto createUserDto)
    {
      var newUser = _usersService.CreateUser(createUserDto);
      var newUserDto = _mapper.Map<UserDto>(newUser);

      return CreatedAtAction(
              nameof(GetUser),
              new { Id = newUser.Id },
              newUserDto
          );
    }

    // PUT /items/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateUser(Guid id, UpdateUserDto updateUserDto)
    {
      var existingUser = _usersService.GetUserById(id);

      if (existingUser is null)
      {
        return NotFound();
      }
      var updatedUser = _mapper.Map(updateUserDto, existingUser);
      _usersService.UpdateUser(updatedUser);

      return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialUpdateUser(Guid id, JsonPatchDocument<UpdateUserDto> patchDocument)
    {
      var existingUser = _usersService.GetUserById(id);

      if (existingUser is null)
      {
        return NotFound();
      }

      var updateUserDto = _mapper.Map<UpdateUserDto>(existingUser);
      patchDocument.ApplyTo(updateUserDto, ModelState);
      if (!TryValidateModel(updateUserDto))
      {
        return ValidationProblem(ModelState);
      }

      var patchedUser = _mapper.Map(updateUserDto, existingUser);
      _usersService.UpdateUser(patchedUser);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(Guid id)
    {
      var existingUser = _usersService.GetUserById(id);

      if (existingUser is null)
      {
        return NotFound();
      }

      _usersService.DeleteUser(existingUser);

      return NoContent();
    }

  }
}