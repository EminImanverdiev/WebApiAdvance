using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using WebApiAdvance.Entities;

namespace WebApiAdvance.DAL.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(b => b.Price)
             .HasDefaultValue(0);
        }
    }
}
