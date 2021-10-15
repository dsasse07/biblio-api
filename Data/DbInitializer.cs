using System.Linq;
using AutoMapper;
using BiblioApi.Dtos.Book;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;

namespace BiblioApi.Data
{
  public static class DbInitializer
  {
    public static void Initialize(
      DataContext context,
      IMapper mapper
      )
    {
      context.Database.EnsureCreated();
      if (context.Books.Any())
      {
        return;
      }

      var users = new CreateUserDto[]{
        new CreateUserDto {FirstName="Danny",LastName="Sasse"},
        new CreateUserDto {FirstName="Nicole",LastName="Sasse"}
      };

      foreach (CreateUserDto u in users)
      {
        var newUser = mapper.Map<User>(u);
        context.Users.Add(newUser);
      }
      context.SaveChanges();

      var books = new CreateBookDto[]{
        new CreateBookDto { VolumeId = "a", Title = "Ender's Game", Subtitle = "non", Author = "Orson Scott Card", PreviewImage = "url", PageCount = 300 },
        new CreateBookDto { VolumeId = "a", Title = "Ender's Shadow", Subtitle = "non", Author = "Orson Scott Card", PreviewImage = "url", PageCount = 300 },
        new CreateBookDto { VolumeId = "a", Title = "Xenocide", Subtitle = "non", Author = "Orson Scott Card", PreviewImage = "url", PageCount = 300 },
        new CreateBookDto { VolumeId = "a", Title = "Wrinkle in Time", Subtitle = "non", Author = "Some Person", PreviewImage = "url", PageCount = 300 },
        new CreateBookDto { VolumeId = "a", Title = "Boring Book", Subtitle = "non", Author = "Some Person", PreviewImage = "url", PageCount = 300 }
      };

      foreach (CreateBookDto b in books)
      {
        var newBook = mapper.Map<Book>(b);
        context.Books.Add(newBook);
      }
      context.SaveChanges();

      var dBooks = context.Books.Where(b => b.Author == "Orson Scott Card").ToList();
      var danny = context.Users.FirstOrDefault(u => u.FirstName == "Danny");
      foreach (Book d in dBooks)
      {
        UserBook ub = new UserBook { User = danny, Book = d };
        context.UserBooks.Add(ub);
      }
      context.SaveChanges();
    }
  }
}