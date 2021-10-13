
using System;

namespace BiblioApi.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreatedAt { get; init; }

    }
}