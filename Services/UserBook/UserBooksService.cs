using System;
using System.Collections.Generic;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;
using BiblioApi.Repositories;

namespace BiblioApi.Services
{
  public class UserBooksService : IUserBooksService
  {
    private readonly IUserBooksRepository _userBooksRepository;
    public UserBooksService(
        IUserBooksRepository userBooksRepository
        )
    {
      _userBooksRepository = userBooksRepository;
    }
    public IEnumerable<UserBook> GetUserBooks()
    {
      return _userBooksRepository.GetUserBooks();
    }
    public UserBook GetUserBookById(Guid id)
    {
      return _userBooksRepository.GetUserBookById(id);
    }
    public UserBook CreateUserBook(UserBook newUserBook)
    {
      return _userBooksRepository.CreateUserBook(newUserBook);
    }
    public void UpdateUserBook(UserBook updatedUserBook)
    {
      _userBooksRepository.UpdateUserBook(updatedUserBook);
    }

    public void DeleteUserBook(UserBook existingUserBook)
    {
      _userBooksRepository.DeleteUserBook(existingUserBook);
    }
  }
}