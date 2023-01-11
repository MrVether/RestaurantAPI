using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbcontext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public void Seed()
        {
            if (_dbcontext.Database.CanConnect())
            {
                if (!_dbcontext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        _dbcontext.Restaurants.AddRange(restaurants);
                        _dbcontext.SaveChanges();
                        transaction.Commit();
                    }
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
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
