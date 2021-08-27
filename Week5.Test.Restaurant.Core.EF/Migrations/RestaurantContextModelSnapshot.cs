﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week5.Test.Restaurant.Core.EF;

namespace Week5.Test.Restaurant.Core.EF.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    partial class RestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week5.Test.Restaurant.Core.Models.Dish", b =>
                {
                    b.Property<int>("ID_Dish")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID_Dish");

                    b.ToTable("Dish");

                    b.HasData(
                        new
                        {
                            ID_Dish = 1,
                            Description = "Gnocchi con salsa e ragu di cervo",
                            Name = "Gnocchi",
                            Price = 12m,
                            Type = 0
                        },
                        new
                        {
                            ID_Dish = 2,
                            Description = "Stufato di maiale",
                            Name = "Stufato",
                            Price = 18.60m,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Week5.Test.Restaurant.Core.Models.User", b =>
                {
                    b.Property<int>("ID_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_User");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID_User = 1,
                            IsOwner = true,
                            Password = "1234",
                            Username = "Alfredo"
                        },
                        new
                        {
                            ID_User = 2,
                            IsOwner = true,
                            Password = "1234",
                            Username = "Maria"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
