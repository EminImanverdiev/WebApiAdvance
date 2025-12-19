using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApiAdvance.Entities;

namespace WebApiAdvance.DAL.EFCore
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    


            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }


    }
}
