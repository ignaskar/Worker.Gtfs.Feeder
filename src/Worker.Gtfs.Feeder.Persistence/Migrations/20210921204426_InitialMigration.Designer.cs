﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Worker.Gtfs.Feeder.Persistence.Context;

namespace Worker.Gtfs.Feeder.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210921204426_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Worker.Gtfs.Feeder.Library.Models.GtfsModel", b =>
                {
                    b.Property<string>("CarNumber")
                        .HasColumnType("text");

                    b.Property<int?>("Azimuth")
                        .HasColumnType("integer");

                    b.Property<string>("CarType")
                        .HasColumnType("text");

                    b.Property<int?>("DeviationInSeconds")
                        .HasColumnType("integer");

                    b.Property<long?>("Latitude")
                        .HasColumnType("bigint");

                    b.Property<long?>("Longitude")
                        .HasColumnType("bigint");

                    b.Property<int?>("MeasurementTime")
                        .HasColumnType("integer");

                    b.Property<string>("Route")
                        .HasColumnType("text");

                    b.Property<int?>("Speed")
                        .HasColumnType("integer");

                    b.Property<string>("TransportType")
                        .HasColumnType("text");

                    b.Property<long?>("TripId")
                        .HasColumnType("bigint");

                    b.Property<int?>("TripStartInMinutes")
                        .HasColumnType("integer");

                    b.HasKey("CarNumber");

                    b.ToTable("TransportData");
                });
#pragma warning restore 612, 618
        }
    }
}
