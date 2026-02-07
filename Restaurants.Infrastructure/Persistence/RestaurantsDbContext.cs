using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
    public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : IdentityDbContext<User>(options)
    {
        //// used primary constructor syntax available in C# 12 and .NET 8 
        //public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Restaurant>()
                                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<User>()
                .HasMany(o => o.OwnedRestaurants)
                .WithOne(r => r.Owner)
                .HasForeignKey(u => u.OwnerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}