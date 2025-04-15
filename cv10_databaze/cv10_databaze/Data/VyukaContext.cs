using System;
using cv10_databaze.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace cv10_databaze.Data
{
    public class VyukaContext : DbContext
    {
        public VyukaContext(DbContextOptions<VyukaContext> options) : base(options) { }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Predmet> Predmety { get; set; }
        public DbSet<Zapsani> Zapsani { get; set; }
        public DbSet<Hodnoceni> Hodnoceni { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zapsani>().HasKey(z => new { z.ID_Studenta, z.Zkratka_Predmetu });
            modelBuilder.Entity<Zapsani>()
                .HasOne(z => z.Student).WithMany(s => s.Zapsani).HasForeignKey(z => z.ID_Studenta);
            modelBuilder.Entity<Zapsani>()
                .HasOne(z => z.Predmet).WithMany(p => p.Zapsani).HasForeignKey(z => z.Zkratka_Predmetu);

            modelBuilder.Entity<Hodnoceni>()
                .HasOne(h => h.Student).WithMany(s => s.Hodnoceni).HasForeignKey(h => h.ID_Studenta);
            modelBuilder.Entity<Hodnoceni>()
                .HasOne(h => h.Predmet).WithMany(p => p.Hodnoceni).HasForeignKey(h => h.Zkratka_Predmetu);
        }
    }
}
