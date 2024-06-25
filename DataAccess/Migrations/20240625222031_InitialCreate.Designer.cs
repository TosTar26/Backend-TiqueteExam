﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.MyDbContext;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240625222031_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<string>("DestinyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("RouteId");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            RouteId = 1,
                            DestinyName = "Lugar 1",
                            ExitName = "Lugar 2",
                            Price = 500f
                        },
                        new
                        {
                            RouteId = 2,
                            DestinyName = "Lugar 2",
                            ExitName = "Lugar 1",
                            Price = 500f
                        },
                        new
                        {
                            RouteId = 3,
                            DestinyName = "Lugar 2",
                            ExitName = "Lugar 3",
                            Price = 1000f
                        },
                        new
                        {
                            RouteId = 4,
                            DestinyName = "Lugar 3",
                            ExitName = "Lugar 2",
                            Price = 1000f
                        },
                        new
                        {
                            RouteId = 5,
                            DestinyName = "Lugar 1",
                            ExitName = "Lugar 3",
                            Price = 1500f
                        },
                        new
                        {
                            RouteId = 6,
                            DestinyName = "Lugar 3",
                            ExitName = "Lugar 1",
                            Price = 1500f
                        });
                });

            modelBuilder.Entity("Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("DateBackingField")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("Destiny")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("RouteId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Entities.Ticket", b =>
                {
                    b.HasOne("Entities.Route", "Route")
                        .WithMany("Tickets")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Entities.Route", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
