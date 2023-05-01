using Apibackend.Models;
using Microsoft.EntityFrameworkCore;

namespace Apibackend.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
    }
}
