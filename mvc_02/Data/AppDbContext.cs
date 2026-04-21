using Microsoft.EntityFrameworkCore;
using mvc_02.Models;

namespace mvc_02.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() { }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
