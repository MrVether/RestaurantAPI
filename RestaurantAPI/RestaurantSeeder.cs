using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbcontext;
        // Constructor for initializing the dbcontext
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        // Method for seeding data to the database
        public void Seed()
        {
            // Check if the database is connected
            if (_dbcontext.Database.CanConnect())
            {
                // Check if there is no data in the Restaurants table
                if (!_dbcontext.Restaurants.Any())
                {
                    // Get sample restaurants data
                    var restaurants = GetRestaurants();
                    // Begin a transaction
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        // Add sample restaurants data to the Restaurants table
                        _dbcontext.Restaurants.AddRange(restaurants);
                        // Save changes to the database
                        _dbcontext.SaveChanges();
                        // Commit the transaction
                        transaction.Commit();
                    }
                }
            }
        }

        // Method for getting sample restaurants data
        private IEnumerable<Restaurant> GetRestaurants()
        {
            // Create a list of sample restaurants data
            var restaurants = new List<Restaurant>
        {
            new Restaurant()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes = new List<Dish>
            {
                new Dish()
                {
                    Name = "Nashville Hot Chicken",
                    Price = 10.30M,
                },
                new Dish()
                {
                    Name = "Chicken Nuggets",
                    Price = 5.30M,
                },
            },
                Address = new Address()
                {
                    City = "Kraków",
                    Street = "Długa 5",
                    PostalCode = "30-001"
                }
            },
            new Restaurant()
            {
                Name = "McDonald",
                Category = "Fast Food",
                Description = "McDonald Company",
                ContactEmail = "contact@mcdonald.com",
                HasDelivery = true,
                Dishes = new List<Dish> {
                new Dish()
                {
            Name = "McWrap",
            Price= 15.30M,
                },
                new Dish(){
            Name = "McNuggets",
            Price= 7.30M,
                },
            },
                Address = new Address()
                {
                    City = "Kraków",
                    Street = "Długa 5",
                    PostalCode = "30-001"
                },
            }
        };

            return restaurants;
        }
    }
}
