using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiAdvance.Entities;

namespace WebApiAdvance.DAL.Configurations
{
    public class BrandConfigurations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Description)
                .HasMaxLength(300)
                .HasDefaultValue("fgdskjda  fsabfkjsa");
        }
    }
}
