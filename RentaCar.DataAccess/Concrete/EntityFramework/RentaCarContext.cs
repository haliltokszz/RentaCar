using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using RentaCar.Entities.Abstract;
using RentaCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentaCar.DataAccess.Concrete.EntityFramework
{
    public class RentaCarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\SQLEXPRESS; Database=RentaCar-NTier; Trusted_Connection=True;");
        }
        public DbSet<Person> People { get; set; }
        public DbSet<IUser> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

    }
}
