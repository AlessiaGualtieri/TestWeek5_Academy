using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Week5.Test.Restaurant.Core.Models;

namespace Week5.Test.Restaurant.Core.EF
{
    public class RestaurantContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public RestaurantContext() : base()
        {

        }
        public RestaurantContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RestaurantMVC;" +
                    "Trusted_Connection=True;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().ToTable("Dish")
                .HasKey(d => d.ID_Dish);
            modelBuilder.Entity<Dish>().Property(d => d.Name)
                .IsRequired();
            modelBuilder.Entity<Dish>().Property(d => d.Description)
                .IsRequired();
            modelBuilder.Entity<Dish>().Property(d => d.Price)
                .HasColumnType("decimal(5,2)")
                .IsRequired();
            modelBuilder.Entity<Dish>().Property(d => d.Type)
                .IsRequired();
            modelBuilder.Entity<Dish>().HasData(
                    new Dish()
                    {
                        ID_Dish = 1,
                        Name = "Gnocchi",
                        Description = "Gnocchi con salsa e ragu di cervo",
                        Type = DishType.Primo,
                        Price = 12
                    },
                    new Dish()
                    {
                        ID_Dish = 2,
                        Name = "Stufato",
                        Description = "Stufato di maiale",
                        Type = DishType.Secondo,
                        Price = 18.60m
                    }
                );


            modelBuilder.Entity<User>().ToTable("User")
                .HasKey(d => d.ID_User);
            modelBuilder.Entity<User>().Property(d => d.Username)
                .IsRequired();
            modelBuilder.Entity<User>().Property(d => d.Password)
                .IsRequired();
            modelBuilder.Entity<User>().Property(d => d.IsOwner)
                .IsRequired();
            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        ID_User = 1,
                        Username = "Alfredo",
                        Password = "1234",
                        IsOwner = true,
                    },
                    new User()
                    {
                        ID_User = 2,
                        Username = "Maria",
                        Password = "1234",
                        IsOwner = true,
                    });
        }
    }
}
