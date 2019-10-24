using System.Threading.Tasks;
using BrainShark.Api.Services.Info.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BrainShark.Api.Services.Database
{
    public class DatabaseService : DbContext, IInfo
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>().HasKey(x => new {x.OrderId, x.ProductId});
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public Task<object> GetInfoAsync() => Task.FromResult((object)Database);
    }
}
