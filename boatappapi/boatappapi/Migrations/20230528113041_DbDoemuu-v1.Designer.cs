﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using boatappapi.Connector;

namespace boatappapi.Migrations
{
    [DbContext(typeof(DbDoemuDataContext))]
    [Migration("20230528113041_DbDoemuu-v1")]
    partial class DbDoemuuv1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("boatappapi.Model.BoatModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Colour")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Boats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a9a9d3c-742d-4971-9a97-42ab50220fbe"),
                            Colour = 2,
                            Description = "This is the Boat 0. It's colour is: WHITE",
                            Name = "Boat0"
                        },
                        new
                        {
                            Id = new Guid("47ccc806-4adb-439e-8fd9-63df12a58a23"),
                            Colour = 0,
                            Description = "This is the Boat 1. It's colour is: BLACK",
                            Name = "Boat1"
                        },
                        new
                        {
                            Id = new Guid("f8203b18-d8c1-4db1-b557-df4e2c0cd85f"),
                            Colour = 5,
                            Description = "This is the Boat 2. It's colour is: BLUE",
                            Name = "Boat2"
                        },
                        new
                        {
                            Id = new Guid("c4133925-4b6e-49b3-b5e3-9393d5ae9e78"),
                            Colour = 2,
                            Description = "This is the Boat 3. It's colour is: WHITE",
                            Name = "Boat3"
                        },
                        new
                        {
                            Id = new Guid("85d57863-9835-4895-80bb-ee2f6d8b8f61"),
                            Colour = 3,
                            Description = "This is the Boat 4. It's colour is: YELLOW",
                            Name = "Boat4"
                        },
                        new
                        {
                            Id = new Guid("1dc05b8a-9936-49cb-a1e7-c24e3a4712b6"),
                            Colour = 0,
                            Description = "This is the Boat 5.",
                            Name = "Boat5"
                        },
                        new
                        {
                            Id = new Guid("02c70bb0-f9fb-427c-a787-9a0ac225a892"),
                            Colour = 0,
                            Description = "This is the Boat 6.",
                            Name = "Boat6"
                        },
                        new
                        {
                            Id = new Guid("a241b40a-4bdb-4f03-9261-40de857f80ee"),
                            Colour = 5,
                            Description = "This is the Boat 7. It's colour is: BLUE",
                            Name = "Boat7"
                        },
                        new
                        {
                            Id = new Guid("b4790857-8309-4e27-b16e-602deba3b1bb"),
                            Colour = 0,
                            Description = "This is the Boat 8.",
                            Name = "Boat8"
                        },
                        new
                        {
                            Id = new Guid("5e006c55-e39d-4204-af40-b215cf79ad28"),
                            Colour = 0,
                            Description = "This is the Boat 9. It's colour is: BLACK",
                            Name = "Boat9"
                        });
                });

            modelBuilder.Entity("boatappapi.Model.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("24e7189f-68f3-4588-91ea-62f023b566a1"),
                            Password = "$2a$11$04oPUn7yWtie4qQ8IWiGnug7HWBmW6sT9uCC2hGUh.gNzAsvcJfSa",
                            Username = "Doemuu"
                        },
                        new
                        {
                            Id = new Guid("1b7372f6-7f0f-4d35-ac72-3a6bbc33f1b3"),
                            Password = "$2a$11$K1keFfN0EXlThGFlGw7MueEM8xdD3mNPwV4RsPc2VkB1S74TkR8hu",
                            Username = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
