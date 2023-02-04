using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        //Łańcuch połączenia używany do połączenia z bazą danych
        private string _connectionString = "Server=localhost;Database=master;Database=RestaurantDb;Trusted_Connection=True;";

        //DbSet dla encji Restauracji
        public DbSet<Restaurant> Restaurants { get; set; }

        //DbSet dla encji Adresu
        public DbSet<Address> Adresses { get; set; }

        //DbSet dla encji Danie
        public DbSet<Dish> Dishes { get; set; }

        //DbSet dla encji Użytkownik
        public DbSet<User> Users { get; set; }

        //DbSet dla encji Rola
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ustawienie wymagalności właściwości Email dla encji Użytkownik
            modelBuilder.Entity<User>()
             .Property(u => u.Email)
             .IsRequired();

            //Ustawienie wymagalności właściwości Name dla encji Rola
            modelBuilder.Entity<Role>()
             .Property(u => u.Name)
             .IsRequired();

            //Ustawienie właściwości Name dla encji Restauracja jako wymagalnej i o maksymalnej długości 25
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            //Ustawienie właściwości Name dla encji Danie jako wymagalnej
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

            //Ustawienie właściwości City dla encji Adres jako wymagalnej i o maksymalnej długości 50
            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            //Ustawienie właściwości Street dla encji Adres jako wymagalnej i o maksymalnej długości 50
            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Ustawienie łańcucha połączenia dla kontekstu


            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
