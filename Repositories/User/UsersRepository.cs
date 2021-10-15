using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Data;
using BiblioApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiblioApi.Repositories
{
  public class UsersRepository : IUsersRepository
  {
    private readonly DataContext _DbContext;

    public UsersRepository(
      DataContext context
    )
    {
      _DbContext = context;
    }
    public IEnumerable<User> GetUsers()
    {
      return _DbContext.Users.Include(u => u.UserBooks).ToList();
    }
    public User GetUserById(Guid id)
    {
      return _DbContext.Users.FirstOrDefault(user => user.Id == id);
    }

    public User GetUserByFirstName(string firstName)
    {
      return _DbContext.Users
              .Include(user => user.UserBooks)
              .FirstOrDefault(user => user.FirstName == firstName);
    }
    public User CreateUser(User newUser)
    {
      if (newUser is null)
      {
        throw new ArgumentNullException(nameof(newUser));
      }

      _DbContext.Add(newUser);
      SaveChanges();
      return newUser;
    }

    public void UpdateUser(User updatedUser)
    {
      SaveChanges();
    }

    public void DeleteUser(User existingUser)
    {
      if (existingUser is null)
      {
        throw new ArgumentNullException(nameof(existingUser));
      }

      _DbContext.Users.Remove(existingUser);
      SaveChanges();
    }
    public bool SaveChanges()
    {
      return _DbContext.SaveChanges() >= 0;
    }

  }
}