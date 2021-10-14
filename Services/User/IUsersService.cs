using System;
using System.Collections.Generic;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;

namespace BiblioApi.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid id);
        User CreateUser(CreateUserDto createUserDto);
        User UpdateUser(User existingUser, UpdateUserDto updateUserDto);
        void DeleteUser(Guid id);
    }
}