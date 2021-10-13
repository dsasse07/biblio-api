using BiblioApi.Dtos.Book;
using BiblioApi.Dtos.User;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;

namespace BiblioApi.Extensions
{
    public static class Extensions
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                VolumeId = book.VolumeId,
                Title = book.Title,
                Subtitle = book.Subtitle,
                Author = book.Author,
                PreviewImage = book.PreviewImage,
                PageCount = book.PageCount,
            };
        }

        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public static UserBookDto ToUserBookDto(this UserBook userBook)
        {
            return new UserBookDto
            {
                Id = userBook.Id,
                UserId = userBook.UserId,
                BookId = userBook.BookId,
                IsActive = userBook.IsActive
            };
        }
    }
}