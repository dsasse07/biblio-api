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
        public User CreateUser(CreateUserDto createUserDto)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                CreatedAt = DateTimeOffset.UtcNow
            };

            return _usersRepository.CreateUser(user);
        }

        public User UpdateUser(User existingUser, UpdateUserDto updateUserDto)
        {
            User updatedUser = existingUser with
            {
                FirstName = updateUserDto.FirstName,
                LastName = updateUserDto.LastName,
            };

            return _usersRepository.UpdateUser(updatedUser);
        }
        public void DeleteUser(Guid id)
        {
            _usersRepository.DeleteUser(id);
        }
    }
}