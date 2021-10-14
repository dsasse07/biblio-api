using System;
using System.Collections.Generic;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid id);
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}