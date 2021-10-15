using System;
using System.Collections.Generic;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;

namespace BiblioApi.Services
{
  public interface IUserBooksService
  {
    IEnumerable<UserBook> GetUserBooks();
    UserBook GetUserBookById(Guid id);
    UserBook CreateUserBook(UserBook newUserBook);
    void UpdateUserBook(UserBook updatedUserBook);
    void DeleteUserBook(UserBook existingUserBook);
  }
}