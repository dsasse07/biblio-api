using System;
using System.Collections.Generic;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;

namespace BiblioApi.Services
{
  public interface IUsersService
  {
    IEnumerable<User> GetUsers();
    User GetUserById(Guid id);

    User GetUserByFirstName(string FirstName);
    User CreateUser(CreateUserDto newUser);
    void UpdateUser(User updatedUser);
    void DeleteUser(User existingUser);
  }
}