using System.ComponentModel.DataAnnotations;

namespace BiblioApi.Dtos.Book
{
    public record UpdateBookDto
    {   
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