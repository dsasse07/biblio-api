using System;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;
using BiblioApi.Repositories;

namespace BiblioApi.Services
{
    public class UserBooksService : IUserBooksService
    {
        private readonly IUserBooksRepository _userBooksRepository;
        public UserBooksService(
            IUserBooksRepository userBooksRepository
            )
        {
            _userBooksRepository = userBooksRepository;
        }

        public UserBook GetUserBookById(Guid id)
        {
            return _userBooksRepository.GetUserBookById(id);
        }
        public UserBook CreateUserBook(CreateUserBookDto createUserBookDto)
        {
            UserBook userBook = new()
            {
                Id = Guid.NewGuid(),
                UserId = createUserBookDto.UserId,
                BookId = createUserBookDto.BookId,
                CreatedAt = DateTimeOffset.UtcNow
            };

            return _userBooksRepository.CreateUserBook(userBook);
        }


        public UserBook UpdateUserBook(UserBook existingUserBook, UpdateUserBookDto updateUserBookDto)
        {
            UserBook updatedUserBook = existingUserBook with
            {
                IsActive = updateUserBookDto.IsActive,
            };

            return _userBooksRepository.UpdateUserBook(updatedUserBook);
        }
    }
}