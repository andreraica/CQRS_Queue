using Domain.Sales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Sales.Mappings
{
    class SalesMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id_Sale");

            builder.Property(m => m.Quantity)
                .HasColumnName("nr_Quantity")
                .IsRequired();

            builder.Property(m => m.Date)
                .HasColumnName("dt_Sale")
                .IsRequired();
        }
    }
}
