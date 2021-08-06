using CandyOnlineShopping.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.DataModels
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Candy> Candy { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Chocolate Candy", Description = "Chocolate Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Fruit Candy", Description = "Fruit Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Gummy Candy", Description = "Gummy Candy" });
            modelBuilder.Entity<Category>().HasData(new Category {Id = 4, Name = "Halloween Candy", Description = "Halloween Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 5, Name = "Hard Candy", Description = "Hardy Candy" });

            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 1,
                Name = "Assorted Chocolate Candy",
                Price = 4.95M,
                Description = "Assorted Chocolate Candy",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolateCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\chocolateCandy-small.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 2,
                Name = "Another Assorted Chocolate Candy",
                Price = 3.95M,
                Description = "Another Assorted Chocolate Candy",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolateCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\chocolateCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 3,
                Name = "Another Chocolate Candy",
                Price = 5.75M,
                Description = "Another Chocolate Candy.",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolateCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\chocolateCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 4,
                Name = "Assorted Fruit Candy",
                Price = 3.95M,
                Description = "Assorted Fruit Candy",
                CategoryId = 2,
                ImageUrl = "\\Images\\fruitCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\fruitCandy-small.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 5,
                Name = "Fruit Candy",
                Price = 7.00M,
                Description = "Fruit Candy.",
                CategoryId = 2,
                ImageUrl = "\\Images\\fruitCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\fruitCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 6,
                Name = "Another Assorted Fruit Candy",
                Price = 11.25M,
                Description = "Another Assorted Fruit Candy ",
                CategoryId = 2,
                ImageUrl = "\\Images\\fruitCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\fruitCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 7,
                Name = "Assorted Gummy Candy",
                Price = 3.95M,
                Description = "Assorted Gummy Candy.",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\gummyCandy-small.jpg",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 8,
                Name = "Another Assorted Gummy Candy",
                Price = 1.95M,
                Description = "Another Assorted Gummy Candy",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\gummyCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 9,
                Name = "Gummy Candy",
                Price = 13.95M,
                Description = "Gummy Candy",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\gummyCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 10,
                Name = "Halloween Candy",
                Price = 1.95M,
                Description = "Halloween Candy.",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\halloweenCandy-small.jpg",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 11,
                Name = "Assorted Halloween Candy",
                Price = 12.95M,
                Description = "Assorted Halloween Candy",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\halloweenCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 12,
                Name = "Another Halloween Candy",
                Price = 21.95M,
                Description = "Another Halloween Candy",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\halloweenCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 13,
                Name = "Hard Candy",
                Price = 6.95M,
                Description = "Hard Candy",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\hardCandy-small.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 14,
                Name = "Another Hard Candy",
                Price = 2.95M,
                Description = "Another Hard Candy.",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\hardCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                Id = 15,
                Name = "Best Hard Candy",
                Price = 16.95M,
                Description = "Best Hard Candy",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnail\\hardCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = false
            });
        }
    }
}
