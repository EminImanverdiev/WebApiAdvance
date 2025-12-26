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

            builder.Property(p => p.Price)
             .HasDefaultValue(0);
            
            builder.Property(p => p.Description)
             .HasMaxLength(500)
             .IsRequired(false);
            
            builder.Property(p => p.Name)
             .HasMaxLength(100)
             .IsRequired();


        }
    }
}
