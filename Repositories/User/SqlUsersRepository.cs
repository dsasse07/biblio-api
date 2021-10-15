using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Data;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
  public class SqlUsersRepository : IUsersRepository
  {
    private readonly DataContext _DbContext;

    public SqlUsersRepository(
      DataContext context
    )
    {
      _DbContext = context;
    }
    public IEnumerable<User> GetUsers()
    {
      return _DbContext.Users.ToList();
    }
    public User GetUserById(Guid id)
    {
      return _DbContext.Users.FirstOrDefault(user => user.Id == id);
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