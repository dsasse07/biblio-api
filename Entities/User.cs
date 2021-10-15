
using System;
using System.Collections.Generic;

namespace BiblioApi.Entities
{
  public class User
  {
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset CreatedAt { get; init; }

    public ICollection<UserBook> UserBooks { get; set; }
  }
}