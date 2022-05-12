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
    [Migration("20220512114044_initail ")]
    partial class initail
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

                    b.Property<string>("CountryCode")
                        .HasColumnType("char(2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Wiki")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("CountryCode");

                    b.ToTable("Circuits");
                });

            modelBuilder.Entity("Formule1Library.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(2)
                        .HasColumnType("char(2)");

                    b.Property<string>("Code3")
                        .HasMaxLength(3)
                        .HasColumnType("char(3)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CountryNumber")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("FlagUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("CountryCode");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Formule1Library.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CountryCode")
                        .HasColumnType("char(2)");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("char(1)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Wiki")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("CountryCode");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Formule1Library.Grandprix", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CountryCode")
                        .HasColumnType("char(2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Wiki")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("CountryCode");

                    b.ToTable("Grandprixes");
                });

            modelBuilder.Entity("Formule1Library.Result", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CircuitID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<int>("GrandprixID")
                        .HasColumnType("int");

                    b.Property<byte>("Racenumber")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Rounds")
                        .HasColumnType("tinyint");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CircuitID");

                    b.HasIndex("DriverID");

                    b.HasIndex("GrandprixID");

                    b.HasIndex("TeamID");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Formule1Library.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CountryCode")
                        .HasColumnType("char(2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Wiki")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("CountryCode");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Formule1Library.Circuit", b =>
                {
                    b.HasOne("Formule1Library.Country", "Country")
                        .WithMany("Circuits")
                        .HasForeignKey("CountryCode");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Formule1Library.Driver", b =>
                {
                    b.HasOne("Formule1Library.Country", "Country")
                        .WithMany("Drivers")
                        .HasForeignKey("CountryCode");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Formule1Library.Grandprix", b =>
                {
                    b.HasOne("Formule1Library.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Formule1Library.Result", b =>
                {
                    b.HasOne("Formule1Library.Circuit", "Circuit")
                        .WithMany("Races")
                        .HasForeignKey("CircuitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Formule1Library.Driver", "Driver")
                        .WithMany("Races")
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Formule1Library.Grandprix", "Grandprix")
                        .WithMany("Results")
                        .HasForeignKey("GrandprixID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Formule1Library.Team", "Team")
                        .WithMany("Races")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Circuit");

                    b.Navigation("Driver");

                    b.Navigation("Grandprix");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Formule1Library.Team", b =>
                {
                    b.HasOne("Formule1Library.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("CountryCode");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Formule1Library.Circuit", b =>
                {
                    b.Navigation("Races");
                });

            modelBuilder.Entity("Formule1Library.Country", b =>
                {
                    b.Navigation("Circuits");

                    b.Navigation("Drivers");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Formule1Library.Driver", b =>
                {
                    b.Navigation("Races");
                });

            modelBuilder.Entity("Formule1Library.Grandprix", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("Formule1Library.Team", b =>
                {
                    b.Navigation("Races");
                });
#pragma warning restore 612, 618
        }
    }
}
