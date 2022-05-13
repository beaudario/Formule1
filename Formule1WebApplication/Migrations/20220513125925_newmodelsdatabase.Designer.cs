﻿// <auto-generated />
using System;
using Formule1Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Formule1WebApplication.Migrations
{
    [DbContext(typeof(Formule1DbContext))]
    [Migration("20220513125925_newmodelsdatabase")]
    partial class newmodelsdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Formule1Library.Circuit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CountryID")
                        .HasColumnType("nvarchar(2)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WikiUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Circuits");
                });

            modelBuilder.Entity("Formule1Library.Country", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("FlagUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Formule1Library.Data.Result", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CircuitID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DriverID")
                        .HasColumnType("int");

                    b.Property<int?>("GrandprixID")
                        .HasColumnType("int");

                    b.Property<int>("Racenumber")
                        .HasColumnType("int");

                    b.Property<int>("Rounds")
                        .HasColumnType("int");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CircuitID");

                    b.HasIndex("DriverID");

                    b.HasIndex("GrandprixID");

                    b.HasIndex("TeamID");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Formule1Library.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CountryID")
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Formule1Library.Grandprix", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CountryID")
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Grandprixes");
                });

            modelBuilder.Entity("Formule1Library.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CountryID")
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WikiUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Formule1Library.Circuit", b =>
                {
                    b.HasOne("Formule1Library.Country", "Country")
                        .WithMany("Circuits")
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Formule1Library.Data.Result", b =>
                {
                    b.HasOne("Formule1Library.Circuit", "Circuit")
                        .WithMany()
                        .HasForeignKey("CircuitID");

                    b.HasOne("Formule1Library.Driver", "Driver")
                        .WithMany("Results")
                        .HasForeignKey("DriverID");

                    b.HasOne("Formule1Library.Grandprix", "Grandprix")
                        .WithMany("Results")
                        .HasForeignKey("GrandprixID");

                    b.HasOne("Formule1Library.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID");

                    b.Navigation("Circuit");

                    b.Navigation("Driver");

                    b.Navigation("Grandprix");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Formule1Library.Driver", b =>
                {
                    b.HasOne("Formule1Library.Country", "Country")
                        .WithMany("Drivers")
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Formule1Library.Grandprix", b =>
                {
                    b.HasOne("Formule1Library.Country", "Country")
                        .WithMany("Grandprixes")
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Formule1Library.Team", b =>
                {
                    b.HasOne("Formule1Library.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Formule1Library.Country", b =>
                {
                    b.Navigation("Circuits");

                    b.Navigation("Drivers");

                    b.Navigation("Grandprixes");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Formule1Library.Driver", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("Formule1Library.Grandprix", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
