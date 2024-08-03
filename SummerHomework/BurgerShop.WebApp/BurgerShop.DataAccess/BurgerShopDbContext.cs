using BurgerShop.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BurgerShop.DataAccess
{
    public class BurgerShopDbContext : DbContext
    {
        public DbSet<Burger>? Burger { get; set; }

        public DbSet<Order>? Order { get; set; }

        public DbSet<Location>? Locations { get; set; }

        public BurgerShopDbContext(DbContextOptions<BurgerShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Order>()
            //    .HasOne(t => t.Burgers)
            //    .WithMany()
            //    .HasForeignKey(t => t.Id);

            modelBuilder.Entity<Burger>().HasData(
                 new Burger { Id = 1, Name = "Classic Cheeseburger", HasFries = true, IsVegan = false, IsVegetarian = false, Price = 8 },
                new Burger { Id = 2, Name = "Veggie Delight", HasFries = false, IsVegan = true, IsVegetarian = true, Price = 9 },
                new Burger { Id = 3, Name = "BBQ Bacon Burger", HasFries = true, IsVegan = false, IsVegetarian = false, Price = 10 },
                new Burger { Id = 4, Name = "Mushroom Swiss Burger", HasFries = false, IsVegan = false, IsVegetarian = true, Price = 9 },
                new Burger { Id = 5, Name = "Spicy Black Bean Burger", HasFries = true, IsVegan = true, IsVegetarian = true, Price = 8 },
                new Burger { Id = 6, Name = "Double Beef Burger", HasFries = false, IsVegan = false, IsVegetarian = false, Price = 11 },
                new Burger { Id = 7, Name = "Grilled Portobello Burger", HasFries = true, IsVegan = false, IsVegetarian = true, Price = 8 },
                new Burger { Id = 8, Name = "Chicken Avocado Burger", HasFries = false, IsVegan = false, IsVegetarian = false, Price = 10 },
                new Burger { Id = 9, Name = "Falafel Burger", HasFries = true, IsVegan = true, IsVegetarian = true, Price = 8 },
                new Burger { Id = 10, Name = "Fish Fillet Burger", HasFries = false, IsVegan = false, IsVegetarian = false, Price = 9 }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    FullName = "John Doe",
                    Address = "123 Main St",
                    IsDelivered = false,
                },

                new Order
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    Address = "456 Elm St",
                    IsDelivered = true,
                },

                new Order
                {
                    Id = 3,
                    FullName = "Mike Johnson",
                    Address = "789 Maple Ave",
                    IsDelivered = false,
                },

                new Order
                {
                    Id = 4,
                    FullName = "Emily Davis",
                    Address = "321 Oak St",
                    IsDelivered = true,
                },

                new Order
                {
                    Id = 5,
                    FullName = "Chris Brown",
                    Address = "654 Pine St",
                    IsDelivered = false,
                },

                new Order
                {
                    Id = 6,
                    FullName = "Sarah Wilson",
                    Address = "987 Cedar St",
                    IsDelivered = true,
                },

                new Order
                {
                    Id = 7,
                    FullName = "David Lee",
                    Address = "741 Birch St",
                    IsDelivered = false,
                },

                new Order
                {
                    Id = 8,
                    FullName = "Jessica Taylor",
                    Address = "852 Spruce St",
                    IsDelivered = true,
                },

                new Order
                {
                    Id = 9,
                    FullName = "Paul White",
                    Address = "963 Willow St",
                    IsDelivered = false,
                },

                new Order
                {
                    Id = 10,
                    FullName = "Laura Green",
                    Address = "159 Aspen St",
                    IsDelivered = true,
                },

                new Order
                {
                    Id = 11,
                    FullName = "Mark Harris",
                    Address = "357 Maple St",
                    IsDelivered = false,
                }
                );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Ireland", Address = "22br", ClosesAt = 1, OpensAt = 12 },
                new Location { Id = 2, Name = "New York", Address = "BeverlySt52", ClosesAt = 8, OpensAt = 12 },
                new Location { Id = 3, Name = "Skopje", Address = "Drachevo", ClosesAt = 6, OpensAt = 12 }
                );
        }
    }
}
