using System.ComponentModel.DataAnnotations;

namespace BiblioApi.Dtos.User
{
    public record CreateUserDto
    {
        // Data Annotations perform data validation.
        // See more Data Annotation helpers
        // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-6
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}