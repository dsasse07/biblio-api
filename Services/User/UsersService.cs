using System;
using System.Collections.Generic;
using AutoMapper;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;
using BiblioApi.Repositories;

namespace BiblioApi.Services
{
  public class UsersService : IUsersService
  {

    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
      _usersRepository = usersRepository;
      _mapper = mapper;
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
    public User CreateUser(CreateUserDto createUserDto)
    {
      var newUserModel = _mapper.Map<User>(createUserDto);
      return _usersRepository.CreateUser(newUserModel);
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