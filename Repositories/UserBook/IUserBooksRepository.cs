using System;
using System.Collections.Generic;
using BiblioApi.Entities;

namespace BiblioApi.Repositories
{
    public interface IUserBooksRepository
    {
        UserBook GetUserBookById( Guid Id);
        IEnumerable<UserBook> GetUserBooksByUserId(Guid userId);
        UserBook CreateUserBook(UserBook userBook);
        UserBook UpdateUserBook(UserBook userBook);
        void DeleteUserBook(Guid id);
        bool SaveChanges();
    }
}