using BiblioApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiblioApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Create a representation of each of the models in the Database as a database set
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
    }
}