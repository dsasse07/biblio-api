using System;
using System.Collections.Generic;
using BiblioApi.Dtos.Book;
using BiblioApi.Entities;
using BiblioApi.Repositories;

namespace BiblioApi.Services
{

    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _booksRepository.GetBooks();
        }

        public Book GetBookById(Guid id)
        {
            return _booksRepository.GetBookById(id);
        }

        public Book CreateBook(CreateBookDto createBookDto)
        {
            Book book = new()
            {
                Id = Guid.NewGuid(),
                VolumeId = createBookDto.VolumeId,
                Title = createBookDto.Title,
                Subtitle = createBookDto.Subtitle,
                Author = createBookDto.Author,
                PreviewImage = createBookDto.PreviewImage,
                PageCount = createBookDto.PageCount,
                CreatedAt = DateTimeOffset.UtcNow
            };

            return _booksRepository.CreateBook(book);
        }

        public Book UpdateBook(Book existingBook, UpdateBookDto updateBookDto)
        {
            Book updatedBook = existingBook with
            {
                VolumeId = updateBookDto.VolumeId,
                Title = updateBookDto.Title,
                Subtitle = updateBookDto.Subtitle,
                Author = updateBookDto.Author,
                PreviewImage = updateBookDto.PreviewImage,
                PageCount = updateBookDto.PageCount,
            };

            return _booksRepository.UpdateBook(updatedBook);
        }

        public void DeleteBook(Guid id)
        {
            _booksRepository.DeleteBook(id);
        }
    }
}