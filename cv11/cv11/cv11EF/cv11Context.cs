using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cv11.cv11EF
{
    public class Cv11Context : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Predmet> Predmety { get; set; }
        public DbSet<Hodnoceni> Hodnoceni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=cv11DB;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Predmety)
                .WithMany(p => p.Studenti)
                .UsingEntity(j => j.ToTable("Zapis"));

            modelBuilder.Entity<Hodnoceni>()
                .HasOne(h => h.Student)
                .WithMany(s => s.Hodnoceni)
                .HasForeignKey(h => h.StudentId);

            modelBuilder.Entity<Hodnoceni>()
                .HasOne(h => h.Predmet)
                .WithMany(p => p.Hodnoceni)
                .HasForeignKey(h => h.PredmetId);
        }
    }
}
