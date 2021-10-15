using System;
using System.Collections.Generic;

namespace BiblioApi.Entities
{
  public class Book
  {
    public Guid Id { get; init; }
    public string VolumeId { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Author { get; set; }
    public string PreviewImage { get; set; }
    public int PageCount { get; set; }
    public DateTimeOffset CreatedAt { get; init; }

    public ICollection<UserBook> UserBooks { get; set; }
  }
}