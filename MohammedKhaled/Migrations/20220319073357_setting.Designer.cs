﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MohammedKhaled.Data;

#nullable disable

namespace MohammedKhaled.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220319073357_setting")]
    partial class setting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MohammedKhaled.Models.attend", b =>
                {
                    b.Property<int>("AId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AId"), 1L, 1);

                    b.Property<bool>("CheckIn")
                        .HasColumnType("bit");

                    b.Property<bool>("CheckOut")
                        .HasColumnType("bit");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<string>("InReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tnow")
                        .HasColumnType("datetime2");

                    b.Property<string>("outState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AId");

                    b.ToTable("attend");
                });

            modelBuilder.Entity("MohammedKhaled.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("admin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
