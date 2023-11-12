using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSolutions.Model;

namespace TechSolutions.API.Context
{
    public class TechSolutionsDbContext : DbContext
    {
        public TechSolutionsDbContext(DbContextOptions<TechSolutionsDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship and keys here if needed
            modelBuilder.Entity<CustomerAddress>()
                .HasOne(c => c.Customer)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.AddressId);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(c => c.Doctor)
                .WithMany(a => a.MedicalRecords)
                .HasForeignKey(a => a.RecordId);

            modelBuilder.Entity<MedicalRecord>()
             .HasOne(c => c.Customer)
             .WithMany(a => a.MedicalRecords)
             .HasForeignKey(a => a.RecordId);
        }
    }
}
