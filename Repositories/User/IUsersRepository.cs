using System;
using System.Collections.Generic;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> CreateUser(User user);
        void DeleteUser(Guid id);
        User GetUserById(Guid id);
        IEnumerable<User> GetUsers();
        User UpdateUser(User user);
    }
}