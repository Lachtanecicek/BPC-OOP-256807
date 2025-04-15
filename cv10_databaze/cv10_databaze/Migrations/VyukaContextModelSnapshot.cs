﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cv10_databaze.Data;

#nullable disable

namespace cv10_databaze.Migrations
{
    [DbContext(typeof(VyukaContext))]
    partial class VyukaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cv10_databaze.Models.Hodnoceni", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Datum_Hodnoceni")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Studenta")
                        .HasColumnType("int");

                    b.Property<string>("PredmetZkratka")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("StudentID_Studenta")
                        .HasColumnType("int");

                    b.Property<string>("Zkratka_Predmetu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Známka")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PredmetZkratka");

                    b.HasIndex("StudentID_Studenta");

                    b.ToTable("Hodnoceni");
                });

            modelBuilder.Entity("cv10_databaze.Models.Predmet", b =>
                {
                    b.Property<string>("Zkratka")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nazev")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Zkratka");

                    b.ToTable("Predmety");
                });

            modelBuilder.Entity("cv10_databaze.Models.Student", b =>
                {
                    b.Property<int>("ID_Studenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Studenta"));

                    b.Property<DateTime>("Datum_Narozeni")
                        .HasColumnType("datetime2");

                    b.Property<string>("Jmeno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prijmeni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Studenta");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("cv10_databaze.Models.Zapsani", b =>
                {
                    b.Property<int>("ID_Studenta")
                        .HasColumnType("int");

                    b.Property<string>("Zkratka_Predmetu")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID_Studenta", "Zkratka_Predmetu");

                    b.HasIndex("Zkratka_Predmetu");

                    b.ToTable("Zapsani");
                });

            modelBuilder.Entity("cv10_databaze.Models.Hodnoceni", b =>
                {
                    b.HasOne("cv10_databaze.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetZkratka")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cv10_databaze.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID_Studenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("cv10_databaze.Models.Zapsani", b =>
                {
                    b.HasOne("cv10_databaze.Models.Student", "Student")
                        .WithMany("Zapsani")
                        .HasForeignKey("ID_Studenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cv10_databaze.Models.Predmet", "Predmet")
                        .WithMany("Zapsani")
                        .HasForeignKey("Zkratka_Predmetu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("cv10_databaze.Models.Predmet", b =>
                {
                    b.Navigation("Zapsani");
                });

            modelBuilder.Entity("cv10_databaze.Models.Student", b =>
                {
                    b.Navigation("Zapsani");
                });
#pragma warning restore 612, 618
        }
    }
}
