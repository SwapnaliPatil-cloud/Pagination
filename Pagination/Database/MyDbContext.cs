using Microsoft.EntityFrameworkCore;
using Pagination.Models;

namespace Pagination.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
    }
}
