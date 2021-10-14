using System;
using System.Linq;
using System.Collections.Generic;
using BiblioApi.Entities;
using BiblioApi.Dtos.Book;

namespace BiblioApi.Repositories
{
    public class InMemBooksRepository : IBooksRepository
    {
        private readonly List<Book> books = new()
        {
            new Book
            {
                Id = Guid.NewGuid(),
                VolumeId = "HHIcCgAAQBAJ",
                Title = "Macbeth",
                Subtitle = null,
                Author = "William Shakespeare",
                PreviewImage = "http://books.google.com/books/content?id=HHIcCgAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                PageCount = 131,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Book
            {
                Id = Guid.NewGuid(),
                VolumeId = "khVwAgAAQBAJ",
                Title = "The Oxford Shakespeare: The Tragedy of Macbeth",
                Subtitle = null,
                Author = "William Shakespeare, Nicholas Brooke",
                PreviewImage = "http://books.google.com/books/content?id=khVwAgAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                PageCount = 249,
                CreatedAt = DateTimeOffset.UtcNow
            }
        };

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBookById(Guid id)
        {
            // Where returns a collection, so to get one book
            // We must append SingleOrDefault (defualt == null)
            return books.Where(book => book.Id == id).SingleOrDefault();
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

            books.Add(book);

            return book;
        }

        public void UpdateBook(Book existingBook, UpdateBookDto updateBookDto)
        {
            var index = books.FindIndex(existingItem => existingItem.Id == existingBook.Id);
            Book updatedBook = existingBook with
            {
                VolumeId = updateBookDto.VolumeId,
                Title = updateBookDto.Title,
                Subtitle = updateBookDto.Subtitle,
                Author = updateBookDto.Author,
                PreviewImage = updateBookDto.PreviewImage,
                PageCount = updateBookDto.PageCount,
            };

            books[index] = updatedBook;            
        }

        public void DeleteBook(Guid id)
        {
            var index = books.FindIndex(existingItem => existingItem.Id == id);
            books.RemoveAt(index);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Book CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}