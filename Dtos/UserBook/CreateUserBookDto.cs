using System;
using System.ComponentModel.DataAnnotations;

namespace BiblioApi.Dtos.UserBook
{
    public record CreateUserBookDto
    {
        // Data Annotations perform data validation.
        // See more Data Annotation helpers
        // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-6
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid BookId { get; set; }
    }
}