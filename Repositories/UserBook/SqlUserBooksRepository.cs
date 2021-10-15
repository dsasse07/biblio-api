using System;
using System.Collections.Generic;
using System.Linq;
using BiblioApi.Data;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
  public class SqlUserBooksRepository : IUserBooksRepository
  {
    private readonly DataContext _DbContext;

    public SqlUserBooksRepository(
      DataContext context
    )
    {
      _DbContext = context;
    }

    public UserBook GetUserBookById(Guid id)
    {
      return _DbContext.UserBooks.FirstOrDefault(ub => ub.Id == id);
    }
    public IEnumerable<UserBook> GetUserBooksByUserId(Guid userId)
    {
      return _DbContext.UserBooks.Where(ub => ub.UserId == userId).ToList();
    }
    public UserBook CreateUserBook(UserBook newUserBook)
    {
      if (newUserBook is null)
      {
        throw new ArgumentNullException(nameof(newUserBook));
      }
      _DbContext.UserBooks.Add(newUserBook);
      _DbContext.SaveChanges();
      return newUserBook;
    }
    public void UpdateUserBook(UserBook updatedUserBook)
    {
      SaveChanges();
    }
    public void DeleteUserBook(UserBook existingUserBook)
    {
      if (existingUserBook is null)
      {
        throw new ArgumentNullException(nameof(existingUserBook));
      }
      _DbContext.UserBooks.Remove(existingUserBook);
      SaveChanges();
    }
    public bool SaveChanges()
    {
      return _DbContext.SaveChanges() >= 0;
    }
  }
}