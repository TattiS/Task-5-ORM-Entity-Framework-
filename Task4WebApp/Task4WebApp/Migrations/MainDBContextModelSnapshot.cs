﻿// <auto-generated />
using System;
using DALProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Task4WebApp.Migrations
{
    [DbContext(typeof(MainDBContext))]
    partial class MainDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DALProject.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PilotId");

                    b.HasKey("Id");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("DALProject.Models.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CrewItemId");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int>("FlightId");

                    b.Property<int?>("PlaneItemId");

                    b.HasKey("Id");

                    b.HasIndex("CrewItemId");

                    b.HasIndex("PlaneItemId");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("DALProject.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<string>("DeparturePoint");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<string>("Destination");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("DALProject.Models.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.Property<long>("TimeTicks");

                    b.HasKey("Id");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("DALProject.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<long>("TimeTicks");

                    b.Property<int?>("TypeOfPlaneId");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfPlaneId");

                    b.ToTable("Plane");
                });

            modelBuilder.Entity("DALProject.Models.PlaneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirLift");

                    b.Property<string>("Model");

                    b.Property<int>("Seats");

                    b.HasKey("Id");

                    b.ToTable("PlaneTypes");
                });

            modelBuilder.Entity("DALProject.Models.Stewardess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<int?>("CrewId");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("Stewardesses");
                });

            modelBuilder.Entity("DALProject.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightId");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("DALProject.Models.Departure", b =>
                {
                    b.HasOne("DALProject.Models.Crew", "CrewItem")
                        .WithMany()
                        .HasForeignKey("CrewItemId");

                    b.HasOne("DALProject.Models.Plane", "PlaneItem")
                        .WithMany()
                        .HasForeignKey("PlaneItemId");
                });

            modelBuilder.Entity("DALProject.Models.Plane", b =>
                {
                    b.HasOne("DALProject.Models.PlaneType", "TypeOfPlane")
                        .WithMany()
                        .HasForeignKey("TypeOfPlaneId");
                });

            modelBuilder.Entity("DALProject.Models.Stewardess", b =>
                {
                    b.HasOne("DALProject.Models.Crew")
                        .WithMany("Stewardesses")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("DALProject.Models.Ticket", b =>
                {
                    b.HasOne("DALProject.Models.Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}