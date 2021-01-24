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
        public RentaCarContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MONSTER-HALIL\SQLEXPRESS; Database=RentaCar-NTier; Trusted_Connection=True;");
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Rentals> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customers>().ToTable("Customers"); 
            builder.Entity<Employees>().ToTable("Employees");
            builder.Entity<Users>().HasKey(u => u.Id);
            builder.Entity<Users>().Property(u => u.Id).ValueGeneratedOnAdd();
 
        }

    }
}
