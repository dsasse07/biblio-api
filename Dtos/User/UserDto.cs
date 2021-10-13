using System;

namespace BiblioApi.Dtos.User
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreatedAt { get; init; }
    }
}