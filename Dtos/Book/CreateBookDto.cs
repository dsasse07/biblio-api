using System.ComponentModel.DataAnnotations;

namespace BiblioApi.Dtos.Book
{
  public class CreateBookDto
  {
    // Data Annotations perform data validation.
    // See more Data Annotation helpers
    // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-6
    [Required]
    public string VolumeId { get; set; }

    [Required]
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Author { get; set; }
    public string PreviewImage { get; set; }
    public int PageCount { get; set; }
  }
}