using System;
using System.Collections.Generic;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
  public interface IUsersRepository
  {
    IEnumerable<User> GetUsers();
    User GetUserById(Guid id);
    User CreateUser(User newUser);
    void UpdateUser(User updatedUser);
    void DeleteUser(User existingUser);
    bool SaveChanges();
  }
}