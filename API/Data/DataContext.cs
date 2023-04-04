using Microsoft.EntityFrameworkCore;
using ReactivitiesV1.Domain;
namespace ReactivitiesV1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}