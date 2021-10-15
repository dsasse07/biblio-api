using System;
using System.Collections.Generic;
using BiblioApi.Dtos.UserBook;

namespace BiblioApi.Dtos.User
{
  public class UserDto
  {
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<UserBookDto> UserBooks { get; set; }
    public DateTimeOffset CreatedAt { get; init; }
  }
}