using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.EntitiesConfiguration
{
    public class PurchaseEntityConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ClientId)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p => p.ClientName)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(p => p.TotalToPay)
            .IsRequired();

            builder.HasData(
                new Purchase(new Guid("ec9da1c8-8771-4065-b9f3-f200abdc7eed"),"7e655c6e-e8e5-4349-8348-e51e0ff3072e","Luke Skywalker",1236)
            );
        }
    }
}