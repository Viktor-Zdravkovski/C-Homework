using BurgerShop.Domain;

namespace BurgerShop.DataAccess
{
    public static class InMemoryDB
    {
        public static List<Burger>? Burgers { get; set; }

        public static List<Order>? Orders { get; set; }

        public static List<Location>? Locations { get; set; }


        static InMemoryDB()
        {
            BurgersOnMenu();
            LoadOrders();
            LocationsUpdater();
        }


        private static void BurgersOnMenu()
        {
            Burgers = new List<Burger>()
            {
                new Burger { Id = 1, Name = "Classic Cheeseburger", HasFries = true, IsVegan = false, IsVegetarian = false, Price = 8 },
                new Burger { Id = 2, Name = "Veggie Delight", HasFries = false, IsVegan = true, IsVegetarian = true, Price = 9 },
                new Burger { Id = 3, Name = "BBQ Bacon Burger", HasFries = true, IsVegan = false, IsVegetarian = false, Price = 10 },
                new Burger { Id = 4, Name = "Mushroom Swiss Burger", HasFries = false, IsVegan = false, IsVegetarian = true, Price = 9 },
                new Burger { Id = 5, Name = "Spicy Black Bean Burger", HasFries = true, IsVegan = true, IsVegetarian = true, Price = 8 },
                new Burger { Id = 6, Name = "Double Beef Burger", HasFries = false, IsVegan = false, IsVegetarian = false, Price = 11 },
                new Burger { Id = 7, Name = "Grilled Portobello Burger", HasFries = true, IsVegan = false, IsVegetarian = true, Price = 8 },
                new Burger { Id = 8, Name = "Chicken Avocado Burger", HasFries = false, IsVegan = false, IsVegetarian = false, Price = 10 },
                new Burger { Id = 9, Name = "Falafel Burger", HasFries = true, IsVegan = true, IsVegetarian = true, Price = 8 },
                new Burger { Id = 10, Name = "Fish Fillet Burger", HasFries = false, IsVegan = false, IsVegetarian = false, Price = 9 },
            };
        }


        private static void LoadOrders()
        {
            Orders = new List<Order>()
            {
               new Order
               {
                    FullName = "John Doe",
                    Address = "123 Main St",
                    IsDelivered = false,
               },

                new Order
                {
                    FullName = "Jane Smith",
                    Address = "456 Elm St",
                    IsDelivered = true,
                },

                new Order
                {
                    FullName = "Mike Johnson",
                    Address = "789 Maple Ave",
                    IsDelivered = false,
                },

                new Order
                {
                    FullName = "Emily Davis",
                    Address = "321 Oak St",
                    IsDelivered = true,
                },

                new Order
                {
                    FullName = "Chris Brown",
                    Address = "654 Pine St",
                    IsDelivered = false,
                },

                new Order
                {
                    FullName = "Sarah Wilson",
                    Address = "987 Cedar St",
                    IsDelivered = true,
                },

                new Order
                {
                    FullName = "David Lee",
                    Address = "741 Birch St",
                    IsDelivered = false,
                },

                new Order
                {
                    FullName = "Jessica Taylor",
                    Address = "852 Spruce St",
                    IsDelivered = true,
                },

                new Order
                {
                    FullName = "Paul White",
                    Address = "963 Willow St",
                    IsDelivered = false,
                },

                new Order
                {
                    FullName = "Laura Green",
                    Address = "159 Aspen St",
                    IsDelivered = true,
                },

                new Order
                {
                    FullName = "Mark Harris",
                    Address = "357 Maple St",
                    IsDelivered = false,
                }

            };
        }

        public static void LocationsUpdater()
        {
            Locations = new List<Location>()
            {
                new Location { Id = 1,Name="Ireland", Address="22br", ClosesAt = 1,OpensAt = 12},
                new Location { Id = 2,Name="New York", Address="BeverlySt52", ClosesAt = 8,OpensAt = 12},
                new Location { Id = 3,Name="Skopje", Address="Drachevo", ClosesAt = 6,OpensAt = 12}

            };
        }

    }
}