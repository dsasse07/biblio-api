using System;
using System.Linq;
using System.Collections.Generic;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
    public class InMemUsersRepository : IUsersRepository
    {
        private readonly List<User> users = new()
        {
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Danny",
                LastName = "Sasse",
                CreatedAt = DateTimeOffset.UtcNow
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Nicole",
                LastName = "Sasse",
                CreatedAt = DateTimeOffset.UtcNow
            },

        };

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUserById(Guid id)
        {
            // Where returns a collection, so to get one book
            // We must append SingleOrDefault (defualt == null)
            return users.Where(user => user.Id == id).SingleOrDefault();
        }

        public User CreateUser(User user)
        {
            users.Add(user);

            return user;
        }

        public User UpdateUser(User user)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == user.Id);
            users[index] = user;

            return user;
        }

        public void DeleteUser(Guid id)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == id);
            users.RemoveAt(index);
        }
    }
}