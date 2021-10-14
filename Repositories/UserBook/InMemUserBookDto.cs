using System;
using System.Linq;
using System.Collections.Generic;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
    public class InMemUserBooksRepository : IUserBooksRepository
    {
        private readonly List<UserBook> userBooks = new()
        {
            new UserBook
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                BookId = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.UtcNow
            },
            new UserBook
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                BookId = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.UtcNow
            },
        };

        public UserBook GetUserBookById( Guid Id){
            return userBooks.Where(ub => ub.Id == Id).SingleOrDefault();
        }
        public IEnumerable<UserBook> GetUserBooksByUserId(Guid userId)
        {
            // Where returns a collection, so to get one book
            // We must append SingleOrDefault (defualt == null)
            return userBooks.Where(userBook => userBook.UserId == userId);
        }

        public UserBook CreateUserBook(UserBook userBook)
        {
            userBooks.Add(userBook);

            return userBook;
        }

        public UserBook UpdateUserBook(UserBook userBook)
        {
            var index = userBooks.FindIndex(existingUserBook => existingUserBook.Id == userBook.Id);
            userBooks[index] = userBook;

            return userBook;
        }

        public void DeleteUserBook(Guid id)
        {
            var index = userBooks.FindIndex(existingUserBook => existingUserBook.Id == id);
            userBooks.RemoveAt(index);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}