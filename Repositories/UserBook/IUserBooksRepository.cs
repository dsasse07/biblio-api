using System;
using System.Collections.Generic;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
  public interface IUserBooksRepository
  {
    UserBook GetUserBookById(Guid id);
    IEnumerable<UserBook> GetUserBooksByUserId(Guid userId);
    UserBook CreateUserBook(UserBook newUserBook);
    void UpdateUserBook(UserBook updatedUserBook);
    void DeleteUserBook(UserBook existingUserBook);
    bool SaveChanges();
  }
}