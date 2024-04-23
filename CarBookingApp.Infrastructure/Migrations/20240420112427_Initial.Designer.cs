﻿// <auto-generated />
using System;
using CarBookingApp.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarBookingApp.Infrastructure.Migrations
{
    [DbContext(typeof(CarBookingAppDbContext))]
    [Migration("20240420112427_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CarBookingApp.Domain.Model.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("CarBookingApp.Domain.Model.Passenger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("CarBookingApp.Domain.Model.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PaymentMethodName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id", "PaymentMethodName")
                        .IsUnique();

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("CarBookingApp.Domain.Model.Ride", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AvailableSeats")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("available_seats");

                    b.Property<DateTime>("DateOfTheRide")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DestinationFrom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("DestinationTo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Rides", null, t =>
                        {
                            t.HasCheckConstraint("CK_Ride_AvailableSeats", "available_seats >= 1 AND available_seats <= 6");
                        });
                });

            modelBuilder.Entity("CarBookingApp.Domain.Model.VehicleType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id", "CarModel")
                        .IsUnique();

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("PassengerPaymentMethod", b =>
                {
                    b.Property<Guid>("PassengerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PaymentMethodsId")
                        .HasColumnType("uuid");

                    b.HasKey("PassengerId", "PaymentMethodsId");

                    b.HasIndex("PaymentMethodsId");

                    b.ToTable("PassengerPaymentMethod");
                });

            modelBuilder.Entity("PassengerRide", b =>
                {
                    b.Property<Guid>("BookRidesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PassengersId")
                        .HasColumnType("uuid");

                    b.HasKey("BookRidesId", "PassengersId");

                    b.HasIndex("PassengersId");

                    b.ToTable("PassengerRide");
                });

            modelBuilder.Entity("CarBookingApp.Domain.Model.Ride", b =>
                {
                    b.HasOne("CarBookingApp.Domain.Model.Driver", "Owner")
                        .WithMany("CreatedRides")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarBookingApp.Domain.Model.VehicleType", b =>
                {
                    b.HasOne("CarBookingApp.Domain.Model.Driver", null)
                        .WithOne("VehicleType")
                        .HasForeignKey("CarBookingApp.Domain.Model.VehicleType", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PassengerPaymentMethod", b =>
                {
                    b.HasOne("CarBookingApp.Domain.Model.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBookingApp.Domain.Model.PaymentMethod", null)
                        .WithMany()
                        .HasForeignKey("PaymentMethodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PassengerRide", b =>
                {
                    b.HasOne("CarBookingApp.Domain.Model.Ride", null)
                        .WithMany()
                        .HasForeignKey("BookRidesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBookingApp.Domain.Model.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarBookingApp.Domain.Model.Driver", b =>
                {
                    b.Navigation("CreatedRides");

                    b.Navigation("VehicleType")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
