
using System;

namespace BiblioApi.Entities
{
  public class UserBook
  {
    public Guid Id { get; init; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; init; }

    public Book Book { get; set; }
    public User User { get; set; }

    public UserBook()
    {
      IsActive = true;
    }
  }
}