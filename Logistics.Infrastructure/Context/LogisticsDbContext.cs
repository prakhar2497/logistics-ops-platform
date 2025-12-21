using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Infrastructure.Context
{
    public class LogisticsDbContext : DbContext
    {
        public LogisticsDbContext(DbContextOptions<LogisticsDbContext> options) : base(options)
        { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<Delivery> Deliveries => Set<Delivery>();
        public DbSet<Issue> Issues => Set<Issue>();
        public DbSet<ReferenceData> ReferenceData => Set<ReferenceData>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasOne(d => d.Vehicle)
                .WithMany(v => v.Deliveries)
                .HasForeignKey(d => d.VehicleId);

                entity.Property(d => d.Revenue)
                .HasPrecision(18, 2);
            });

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Delivery)
                .WithMany(d => d.Issues)
                .HasForeignKey(i => i.DeliveryId);
        }
    }
}
