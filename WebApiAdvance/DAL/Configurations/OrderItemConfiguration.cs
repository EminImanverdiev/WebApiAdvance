using Microsoft.EntityFrameworkCore;
using WebApiAdvance.Entities;

namespace WebApiAdvance.DAL.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderItem> builder)
        {
          

            builder.Property(oi => oi.TotalPrice)
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.Quantity)
                            .IsRequired()
                            .HasDefaultValue(1);
        }
    }
}
