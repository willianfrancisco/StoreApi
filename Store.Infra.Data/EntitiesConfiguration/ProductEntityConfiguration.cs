using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.EntitiesConfiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p => p.Price)
                    .IsRequired();

            builder.Property(p => p.ZipCode)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(p => p.Seller)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p => p.ThumbnailHd)
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(p => p.Date)
            .HasMaxLength(100)
            .IsRequired();

            builder.HasData(
                new Product(new Guid("4f9a5cf4-20f6-4652-8d8c-891793dd3f07"), "Blusa Han Shot First",7990,"13500-110","Joana","https://cdn.awsli.com.br/1000x1000/21/21351/produto/7234148/55692a941d.jpg","26/11/2015"),
                new Product(new Guid("a99808e6-7f74-485b-9fe9-45bd0d819b40"), "Sabre de luz",150000,"13537-000","Mario Mota","http://www.obrigadopelospeixes.com/wp-content/uploads/2015/12/kalippe_lightsaber_by_jnetrocks-d4dyzpo1-1024x600.jpg","26/11/2015")
            );
        }
    }
}