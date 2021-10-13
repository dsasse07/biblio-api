using System;

namespace BiblioApi.Dtos.UserBook
{
    public record UserBookDto
    {
        public Guid Id { get; init; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; init; }
    }
}