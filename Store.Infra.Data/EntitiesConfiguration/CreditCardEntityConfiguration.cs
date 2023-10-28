using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.EntitiesConfiguration
{
    public class CreditCardEntityConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardNumber)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(c => c.Value)
            .IsRequired();

            builder.Property(c => c.Cvv)
            .IsRequired();

            builder.Property(c => c.CardHolderName)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.ExpDate)
            .HasMaxLength(100)
            .IsRequired();

            builder.HasOne(c => c.Purchase)
                    .WithOne(c => c.CreditCard)
                    .HasForeignKey<CreditCard>(c => c.PurchaseId);

            builder.HasData(
                new CreditCard(new Guid("c48871ec-5df8-41c9-b62f-b6a60e83969f"),"1234123412341234",7990,789,"Luke Skywalker","12/24",new Guid("ec9da1c8-8771-4065-b9f3-f200abdc7eed"))
            );
        }
    }
}