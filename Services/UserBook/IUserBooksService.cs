using System;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;

namespace BiblioApi.Services
{
  public interface IUserBooksService
  {
    UserBook GetUserBookById(Guid id);
    UserBook CreateUserBook(UserBook newUserBook);
    void UpdateUserBook(UserBook updatedUserBook);
    void DeleteUserBook(UserBook existingUserBook);
  }
}