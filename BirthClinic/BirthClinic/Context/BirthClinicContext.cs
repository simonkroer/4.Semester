using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthClinic.Context
{
    public class BirthClinicContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BirthClinicDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Father)
                .WithOne()
                .HasForeignKey<Person>()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Mother)
                .WithOne()
                .HasForeignKey<Person>()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Person>()
                .Property(p => p.Role)
                .HasConversion<string>();

            modelBuilder
                .Entity<Room>()
                .Property(r => r.Type)
                .HasConversion<string>();
        }
    }
}
