﻿// <auto-generated />
using System;
using BookHavenClassLibrary.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookHavenClassLibrary.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250318174613_ChangesToOrderItems")]
    partial class ChangesToOrderItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookHavenClassLibrary.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("BookGenre")
                        .HasColumnType("int");

                    b.Property<string>("Isbn")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookHavenClassLibrary.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("ContactPersonName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SupplierType")
                        .HasColumnType("int");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("BookHavenClassLibrary.Models.SupplierOrder", b =>
                {
                    b.Property<int>("SupplierOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierOrderId"));

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("date");

                    b.Property<int>("OrderStatuses")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("SupplierOrderId");

                    b.ToTable("SupplierOrders");
                });

            modelBuilder.Entity("BookHavenClassLibrary.Models.SupplierOrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierOrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderItemId");

                    b.HasIndex("SupplierOrderId");

                    b.ToTable("SupplierOrderItems");
                });

            modelBuilder.Entity("BookHavenClassLibrary.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastLoginAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@bookhaven.com",
                            FirstName = "Admin",
                            LastLoginAt = new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "User",
                            PasswordHash = "QpLkF1G7uy0L1+VyiQKduG0qK6JZbbTtFqeRzGcy3Vs=",
                            Role = 0,
                            Salt = "1oX2+HLYhpIImDRzMYlu+g=="
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sales001@bookhaven.com",
                            FirstName = "John",
                            LastLoginAt = new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Sales001",
                            PasswordHash = "rCPxaz0+DAoNSKkvruJH3PxjfDMeIyTYlMFrYl1BmPU=",
                            Role = 2,
                            Salt = "cQQxDnVvUg6iSC3qcaVj4Q=="
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "clerk001@bookhaven.com",
                            FirstName = "John",
                            LastLoginAt = new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Clerk001",
                            PasswordHash = "Qo2lVpmulOfrFvTYWCP0XlgFQ0q2q+KjQGhhGgNGvd8=",
                            Role = 1,
                            Salt = "qf0effYCz9WKVKXCc2A7Zw=="
                        });
                });

            modelBuilder.Entity("BookHavenClassLibrary.Models.SupplierOrderItem", b =>
                {
                    b.HasOne("BookHavenClassLibrary.Models.SupplierOrder", "SupplierOrder")
                        .WithMany("SupplierOrderItems")
                        .HasForeignKey("SupplierOrderId");

                    b.Navigation("SupplierOrder");
                });

            modelBuilder.Entity("BookHavenClassLibrary.Models.SupplierOrder", b =>
                {
                    b.Navigation("SupplierOrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
