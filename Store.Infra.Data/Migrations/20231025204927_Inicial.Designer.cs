﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Infra.Data.Context;

#nullable disable

namespace Store.Infra.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20231025204927_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Store.Domain.Entities.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Cvv")
                        .HasColumnType("int");

                    b.Property<string>("ExpDate")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId")
                        .IsUnique();

                    b.ToTable("CreditCards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c48871ec-5df8-41c9-b62f-b6a60e83969f"),
                            CardHolderName = "Luke Skywalker",
                            CardNumber = "1234123412341234",
                            Cvv = 789,
                            ExpDate = "12/24",
                            PurchaseId = new Guid("ec9da1c8-8771-4065-b9f3-f200abdc7eed"),
                            Value = 7990
                        });
                });

            modelBuilder.Entity("Store.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Seller")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ThumbnailHd")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4f9a5cf4-20f6-4652-8d8c-891793dd3f07"),
                            Date = "26/11/2015",
                            Price = 7990,
                            Seller = "Joana",
                            ThumbnailHd = "https://cdn.awsli.com.br/1000x1000/21/21351/produto/7234148/55692a941d.jpg",
                            Title = "Blusa Han Shot First",
                            ZipCode = "13500-110"
                        },
                        new
                        {
                            Id = new Guid("a99808e6-7f74-485b-9fe9-45bd0d819b40"),
                            Date = "26/11/2015",
                            Price = 150000,
                            Seller = "Mario Mota",
                            ThumbnailHd = "http://www.obrigadopelospeixes.com/wp-content/uploads/2015/12/kalippe_lightsaber_by_jnetrocks-d4dyzpo1-1024x600.jpg",
                            Title = "Sabre de luz",
                            ZipCode = "13537-000"
                        });
                });

            modelBuilder.Entity("Store.Domain.Entities.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TotalToPay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ec9da1c8-8771-4065-b9f3-f200abdc7eed"),
                            ClientId = "7e655c6e-e8e5-4349-8348-e51e0ff3072e",
                            ClientName = "Luke Skywalker",
                            TotalToPay = 1236
                        });
                });

            modelBuilder.Entity("Store.Domain.Entities.CreditCard", b =>
                {
                    b.HasOne("Store.Domain.Entities.Purchase", "Purchase")
                        .WithOne("CreditCard")
                        .HasForeignKey("Store.Domain.Entities.CreditCard", "PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Store.Domain.Entities.Purchase", b =>
                {
                    b.Navigation("CreditCard");
                });
#pragma warning restore 612, 618
        }
    }
}
