using System;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;

namespace BiblioApi.Services
{
    public interface IUserBooksService
    {
        UserBook GetUserBookById(Guid id);
        UserBook CreateUserBook(CreateUserBookDto createUserBookDto);
        UserBook UpdateUserBook(UserBook existingUserBook, UpdateUserBookDto updateUserBookDto);
    }
}