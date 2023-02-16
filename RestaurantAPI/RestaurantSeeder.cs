using Microsoft.AspNetCore.Identity;
using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbcontext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RestaurantSeeder(RestaurantDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbcontext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (_dbcontext.Database.CanConnect())
            {
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
                if (!_dbcontext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbcontext.Roles.AddRange(roles);
                    _dbcontext.SaveChanges();
                }

                if (!_dbcontext.Users.Any())
                {
                    var users = GetUsers();
                    _dbcontext.Users.AddRange(users);
                    _dbcontext.SaveChanges();
                }
            }
        }
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
                Dishes = new List<Dish>
                {
                    new Dish()
                    {
                        Name = "McWrap",
                        Price= 15.30M,
                    },
                    new Dish()
                    {
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
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>
            {
                new Role { Name = "User" },
                new Role { Name = "Manager" },
                new Role { Name = "Admin" }
            };

            return roles;
        }

        private IEnumerable<User> GetUsers()
        {
            var password = "password";

            var users = new List<User>
            {
                new User
                {
                    Email = "user@example.com",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Nationality = "Polish",
                    RoleId = 1,
                    PasswordHash = _passwordHasher.HashPassword(null, password)
                },
                new User
                {
                    Email = "manager@example.com",
                    DateOfBirth = new DateTime(1985, 1, 1),
                    Nationality = "American",
                    RoleId = 2,
                    PasswordHash = _passwordHasher.HashPassword(null, password)
                },
                new User
                {
                    Email = "admin@example.com",
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Nationality = "British",
                    RoleId = 3,
                    PasswordHash = _passwordHasher.HashPassword(null, password)
                }
            };

            return users;
        }
    }
}
