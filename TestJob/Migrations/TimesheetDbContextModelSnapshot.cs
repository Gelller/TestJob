﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestJob.Data;

namespace TestJob.Migrations
{
    [DbContext(typeof(TimesheetDbContext))]
    partial class TimesheetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestJob.Models.Cities", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CitiesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryId")
                        .IsUnique()
                        .HasFilter("[CountryId] IS NOT NULL");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("TestJob.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeСountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.Property<Guid?>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("СountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("country");
                });

            modelBuilder.Entity("TestJob.Models.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("region");
                });

            modelBuilder.Entity("TestJob.Models.Cities", b =>
                {
                    b.HasOne("TestJob.Models.Country", "Country")
                        .WithOne("City")
                        .HasForeignKey("TestJob.Models.Cities", "CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TestJob.Models.Country", b =>
                {
                    b.HasOne("TestJob.Models.Region", "Region")
                        .WithMany("Country")
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("TestJob.Models.Country", b =>
                {
                    b.Navigation("City");
                });

            modelBuilder.Entity("TestJob.Models.Region", b =>
                {
                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
