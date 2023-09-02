﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeatManagementAPI;

#nullable disable

namespace SeatManagementAPI.Migrations
{
    [DbContext(typeof(SeatManagementDbContext))]
    [Migration("20230902133043_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeatManagementAPI.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"), 1L, 1);

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingId"), 1L, 1);

                    b.Property<string>("BuildingAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Cabin", b =>
                {
                    b.Property<int>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CabinId"), 1L, 1);

                    b.Property<string>("CabinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.HasKey("CabinId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FacilityId");

                    b.ToTable("Cabin");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAllocated")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityId"), 1L, 1);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityFloor")
                        .HasColumnType("int");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacilityId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CityId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.MeetingRoom", b =>
                {
                    b.Property<int>("MeetingRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeetingRoomId"), 1L, 1);

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("MeetingRoomCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("MeetingRoomId");

                    b.HasIndex("FacilityId");

                    b.ToTable("MeetingRooms");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.MeetingRoomAssets", b =>
                {
                    b.Property<int>("MeetingRoomAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeetingRoomAssetId"), 1L, 1);

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<int>("MeetingRoomId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfItems")
                        .HasColumnType("int");

                    b.HasKey("MeetingRoomAssetId");

                    b.HasIndex("AssetId");

                    b.HasIndex("MeetingRoomId");

                    b.ToTable("MeetingRoomAssets");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Overview", b =>
                {
                    b.Property<string>("BuildingAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacilityFloor")
                        .HasColumnType("int");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeatCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToView("Overview");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"), 1L, 1);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("SeatCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FacilityId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Cabin", b =>
                {
                    b.HasOne("SeatManagementAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SeatManagementAPI.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Employee", b =>
                {
                    b.HasOne("SeatManagementAPI.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Facility", b =>
                {
                    b.HasOne("SeatManagementAPI.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeatManagementAPI.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("City");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.MeetingRoom", b =>
                {
                    b.HasOne("SeatManagementAPI.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.MeetingRoomAssets", b =>
                {
                    b.HasOne("SeatManagementAPI.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeatManagementAPI.Models.MeetingRoom", "MeetingRoom")
                        .WithMany()
                        .HasForeignKey("MeetingRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("MeetingRoom");
                });

            modelBuilder.Entity("SeatManagementAPI.Models.Seat", b =>
                {
                    b.HasOne("SeatManagementAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SeatManagementAPI.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Facility");
                });
#pragma warning restore 612, 618
        }
    }
}
