﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingService.DAL.Infrastructure;

#nullable disable

namespace ShippingService.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221108084410_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShippingService.DAL.Entities.ShipmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentStatus")
                        .HasColumnType("int");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("ShippingService.DAL.Entities.TrackingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Tracking");
                });

            modelBuilder.Entity("ShippingService.DAL.Entities.TrackingEntity", b =>
                {
                    b.HasOne("ShippingService.DAL.Entities.ShipmentEntity", "Shipment")
                        .WithMany("Tracking")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("ShippingService.DAL.Entities.ShipmentEntity", b =>
                {
                    b.Navigation("Tracking");
                });
#pragma warning restore 612, 618
        }
    }
}
