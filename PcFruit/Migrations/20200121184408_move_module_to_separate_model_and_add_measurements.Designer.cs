﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PcFruit.Models;

namespace PcFruit.Migrations
{
    [DbContext(typeof(PcfruitContext))]
    [Migration("20200121184408_move_module_to_separate_model_and_add_measurements")]
    partial class move_module_to_separate_model_and_add_measurements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PcFruit.Models.Module", b =>
                {
                    b.Property<int>("ModuleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ModuleID");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("PcFruit.Models.Sensor", b =>
                {
                    b.Property<int>("SensorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Analog");

                    b.Property<int?>("Distance");

                    b.Property<int?>("Humidity");

                    b.Property<string>("Label");

                    b.Property<int>("Resistance");

                    b.Property<int?>("Temperature");

                    b.Property<int>("Type");

                    b.Property<int>("Voltage");

                    b.HasKey("SensorID");

                    b.ToTable("metingen");
                });

            modelBuilder.Entity("PcFruit.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Naam");

                    b.Property<string>("Password");

                    b.Property<string>("Voornaam");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
