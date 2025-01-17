﻿// <auto-generated />
using System;
using HMS_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMS_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250117072231_AddPhoneNumberToUser")]
    partial class AddPhoneNumberToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HMS_API.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("address")
                        .HasColumnType("longtext");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasColumnType("longtext");

                    b.Property<string>("country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("firstName")
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .HasColumnType("longtext");

                    b.Property<string>("lastName")
                        .HasColumnType("longtext");

                    b.Property<string>("middleName")
                        .HasColumnType("longtext");

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("referredBy")
                        .HasColumnType("longtext");

                    b.Property<string>("state")
                        .HasColumnType("longtext");

                    b.Property<int>("zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
