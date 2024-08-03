using Microsoft.EntityFrameworkCore;
using System;

namespace Grocery_Store.Models
{
    public class GroceryDbContext: DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fruit" },
                new Category { Id = 2, Name = "Bakery" },
                new Category { Id = 3, Name = "Dairy" }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Image = "apple.jpg", Name = "Apple", Price = 1.00m, Description = "A fresh apple", CategoryId = 1 },
                new Item { Id = 2, Image = "bread.jpg", Name = "Bread", Price = 1.50m, Description = "A fresh bread", CategoryId = 2 },
                new Item { Id = 3, Image = "milk.jpg", Name = "Milk", Price = 0.99m, Description = "A fresh milk", CategoryId = 3 }
            );
        }
    }
}
