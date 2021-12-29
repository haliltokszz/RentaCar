using System;
using Core.Entities.Concrete;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentaCarContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Findeks> Findeks { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddGlobalFilter(); //Global Filter
            base.OnModelCreating(modelBuilder);
        }
    }
}