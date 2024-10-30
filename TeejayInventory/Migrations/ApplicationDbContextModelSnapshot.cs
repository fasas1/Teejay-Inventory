﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeejayInventory.Data;

#nullable disable

namespace TeejayInventory.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeejayInventory.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Smart and OLED Screen Television",
                            Name = "Smart TV"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Strong and Durable Pressing Iron",
                            Name = "Iron"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "AI Powered Washing Machine",
                            Name = "Washing Machine"
                        });
                });

            modelBuilder.Entity("TeejayInventory.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Sony Television",
                            Price = 620000m,
                            QuantityAvailable = 85,
                            SKU = "SKU001"
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Iron",
                            Price = 26000m,
                            QuantityAvailable = 550,
                            SKU = "SKU002"
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "LG Fan",
                            Price = 120000m,
                            QuantityAvailable = 323,
                            SKU = "SKU003"
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "Electric Cooker",
                            Price = 480000m,
                            QuantityAvailable = 94,
                            SKU = "SKU004"
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "Washing Machine",
                            Price = 320000m,
                            QuantityAvailable = 181,
                            SKU = "SKU005"
                        });
                });

            modelBuilder.Entity("TeejayInventory.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"));

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Stock");

                    b.HasData(
                        new
                        {
                            StockId = 1,
                            LastUpdated = new DateTime(2024, 10, 27, 14, 37, 15, 799, DateTimeKind.Utc).AddTicks(813),
                            ProductId = 1,
                            Quantity = 143,
                            WarehouseId = 2
                        });
                });

            modelBuilder.Entity("TeejayInventory.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            Email = "choing@gmail.com",
                            Name = "Choing Exporter",
                            PhoneNumber = "477892002340"
                        },
                        new
                        {
                            SupplierId = 2,
                            Email = "tchangsupply@gmail.com",
                            Name = "Tchang Inc",
                            PhoneNumber = "774292002340"
                        });
                });

            modelBuilder.Entity("TeejayInventory.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.ToTable("Transaction");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            ProductId = 4,
                            Quantity = 340,
                            TransactionDate = new DateTime(2024, 10, 27, 14, 37, 15, 799, DateTimeKind.Utc).AddTicks(603),
                            TransactionType = "Purchase"
                        },
                        new
                        {
                            TransactionId = 2,
                            ProductId = 2,
                            Quantity = 70,
                            TransactionDate = new DateTime(2024, 10, 27, 14, 37, 15, 799, DateTimeKind.Utc).AddTicks(609),
                            TransactionType = "Sale"
                        });
                });

            modelBuilder.Entity("TeejayInventory.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouse");

                    b.HasData(
                        new
                        {
                            WarehouseId = 1,
                            Location = "Ikeja"
                        },
                        new
                        {
                            WarehouseId = 2,
                            Location = "Sango ota"
                        },
                        new
                        {
                            WarehouseId = 3,
                            Location = "Lekki"
                        });
                });

            modelBuilder.Entity("TeejayInventory.Models.Stock", b =>
                {
                    b.HasOne("TeejayInventory.Models.Warehouse", null)
                        .WithMany("Stocks")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeejayInventory.Models.Warehouse", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
