﻿// <auto-generated />
using LabSportsStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabSportsStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200609153931_TestData")]
    partial class TestData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LabSportsStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = "Watersports",
                            Description = "A 1-Person Boat",
                            Name = "Kayak",
                            Price = 275m
                        },
                        new
                        {
                            ProductId = 2,
                            Category = "Watersports",
                            Description = "Protective AND Fashionable",
                            Name = "Life Jacket",
                            Price = 48.95m
                        },
                        new
                        {
                            ProductId = 3,
                            Category = "Soccer",
                            Description = "FIFA Approved Size And Weight",
                            Name = "Soccer Ball",
                            Price = 34.95m
                        },
                        new
                        {
                            ProductId = 4,
                            Category = "Soccer",
                            Description = "Like The Pros",
                            Name = "Corner Flags",
                            Price = 19.50m
                        },
                        new
                        {
                            ProductId = 5,
                            Category = "Running",
                            Description = "A New Level Of Comfort",
                            Name = "Running Shoes",
                            Price = 89.95m
                        },
                        new
                        {
                            ProductId = 6,
                            Category = "Football",
                            Description = "Broncos Logo",
                            Name = "Football",
                            Price = 59.95m
                        },
                        new
                        {
                            ProductId = 7,
                            Category = "Baseball",
                            Description = "Official Size & Weight",
                            Name = "Baseball",
                            Price = 9.95m
                        },
                        new
                        {
                            ProductId = 8,
                            Category = "Baseball",
                            Description = "Genuine Leather",
                            Name = "Baseball Glove",
                            Price = 94.95m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
