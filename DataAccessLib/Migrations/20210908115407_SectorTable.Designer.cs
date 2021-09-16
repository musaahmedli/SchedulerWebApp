﻿// <auto-generated />
using System;
using DataAccessLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLib.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210908115407_SectorTable")]
    partial class SectorTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EntityLib.DaysOfWeek", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Day")
                        .HasColumnType("text");

                    b.HasKey("DayId");

                    b.ToTable("DaysOfWeeks");

                    b.HasData(
                        new
                        {
                            DayId = 1,
                            Day = "Bazar ertəsi"
                        },
                        new
                        {
                            DayId = 2,
                            Day = "Çərşənbə axşamı"
                        },
                        new
                        {
                            DayId = 3,
                            Day = "Çərşənbə"
                        },
                        new
                        {
                            DayId = 4,
                            Day = "Cümə axşamı"
                        },
                        new
                        {
                            DayId = 5,
                            Day = "Cümə"
                        },
                        new
                        {
                            DayId = 6,
                            Day = "Şənbə"
                        },
                        new
                        {
                            DayId = 7,
                            Day = "Bazar"
                        });
                });

            modelBuilder.Entity("EntityLib.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("integer");

                    b.HasKey("DepartmentId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EntityLib.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentOrganizationId")
                        .HasColumnType("integer");

                    b.HasKey("OrganizationId");

                    b.HasIndex("ParentOrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("EntityLib.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SectorId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("EntityLib.Department", b =>
                {
                    b.HasOne("EntityLib.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("EntityLib.Organization", b =>
                {
                    b.HasOne("EntityLib.Organization", "ParentOrganization")
                        .WithMany()
                        .HasForeignKey("ParentOrganizationId");

                    b.Navigation("ParentOrganization");
                });

            modelBuilder.Entity("EntityLib.Sector", b =>
                {
                    b.HasOne("EntityLib.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}