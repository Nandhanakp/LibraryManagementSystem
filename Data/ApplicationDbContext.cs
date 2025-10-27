using Microsoft.EntityFrameworkCore;
using NewFolder.Models;

namespace NewFolder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;


    }
}
