﻿// <auto-generated />
using System;
using FitHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitHub.Migrations
{
    [DbContext(typeof(GymDbContext))]
    [Migration("20231207235244_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FitHub.Models.Amenity", b =>
                {
                    b.Property<string>("AmenityID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AmenityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("CostPerPerson")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaxCapacityPerDay")
                        .HasColumnType("int");

                    b.HasKey("AmenityID");

                    b.ToTable("Amenity");
                });

            modelBuilder.Entity("FitHub.Models.Booking", b =>
                {
                    b.Property<string>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AmenityID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchasedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BookingID");

                    b.HasIndex("AmenityID");

                    b.HasIndex("UserID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("FitHub.Models.Membership", b =>
                {
                    b.Property<string>("MembershipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MembershipTypeID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MembershipID");

                    b.HasIndex("MembershipTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("Membership");
                });

            modelBuilder.Entity("FitHub.Models.MembershipDetail", b =>
                {
                    b.Property<string>("MembershipTypeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationMonths")
                        .HasColumnType("int");

                    b.Property<string>("MembershipTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MembershipTypeID");

                    b.ToTable("MembershipDetail");
                });

            modelBuilder.Entity("FitHub.Models.Sauna", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.Property<int>("NumberReserved")
                        .HasColumnType("int");

                    b.HasKey("Date");

                    b.ToTable("Sauna");
                });

            modelBuilder.Entity("FitHub.Models.Spa", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.Property<int>("NumberReserved")
                        .HasColumnType("int");

                    b.HasKey("Date");

                    b.ToTable("Spa");
                });

            modelBuilder.Entity("FitHub.Models.SwimmingPool", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.Property<int>("NumberReserved")
                        .HasColumnType("int");

                    b.HasKey("Date");

                    b.ToTable("SwimmingPool");
                });

            modelBuilder.Entity("FitHub.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FitHub.Models.Booking", b =>
                {
                    b.HasOne("FitHub.Models.Amenity", "Amenity")
                        .WithMany()
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitHub.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitHub.Models.Membership", b =>
                {
                    b.HasOne("FitHub.Models.MembershipDetail", "MD")
                        .WithMany()
                        .HasForeignKey("MembershipTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitHub.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MD");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}