﻿using CarDealership.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WebCarDealership
{
    public class DealershipDbContext : DbContext
    {
        public DealershipDbContext(DbContextOptions<DealershipDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.Write);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }

        public DbSet<CarOffer> CarOffers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
