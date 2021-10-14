
using System;
using System.Collections.Generic;

namespace BiblioApi.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserBook> UserBooks { get; set; }
        public DateTimeOffset CreatedAt { get; init; }

    }
}