using System;
using System.Collections.Generic;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;
using BiblioApi.Repositories;

namespace BiblioApi.Services
{
  public class UsersService : IUsersService
  {

    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
      _usersRepository = usersRepository;
    }
    public IEnumerable<User> GetUsers()
    {
      return _usersRepository.GetUsers();
    }
    public User GetUserById(Guid id)
    {
      return _usersRepository.GetUserById(id);
    }
    public User GetUserByFirstName(string firstName)
    {
      return _usersRepository.GetUserByFirstName(firstName);
    }
    public User CreateUser(User newUser)
    {
      return _usersRepository.CreateUser(newUser);
    }

    public void UpdateUser(User updatedUser)
    {
      _usersRepository.UpdateUser(updatedUser);
    }
    public void DeleteUser(User existingUser)
    {
      _usersRepository.DeleteUser(existingUser);
    }

  }
}