
using System;

namespace BiblioApi.Entities
{
    public record UserBook
    {
        public Guid Id { get; init; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; init; }

    }
}