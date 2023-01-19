using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        //The connection string used to connect to the database
        private string _connectionString = "Server=localhost;Database=master;Database=RestaurantDb;Trusted_Connection=True;";

        //DbSet for the Restaurant entity
        public DbSet<Restaurant> Restaurants { get; set; }

        //DbSet for the Address entity
        public DbSet<Address> Adresses { get; set; }

        //DbSet for the Dish entity
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
             .Property(u => u.Email)
             .IsRequired();
            modelBuilder.Entity<Role>()
             .Property(u => u.Name)

             .IsRequired();
            //Sets the name property of the Restaurant entity as required and with max length of 25
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            //Sets the name property of the Dish entity as required
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

            //Sets the city property of the Address entity as required and with max length of 50
            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            //Sets the street property of the Address entity as required and with max length of 50
            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Sets the connection string for the context
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
