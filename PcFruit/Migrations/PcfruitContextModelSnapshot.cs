﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PcFruit.Models;

namespace PcFruit.Migrations
{
    [DbContext(typeof(PcfruitContext))]
    partial class PcfruitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PcFruit.Models.Meter", b =>
                {
                    b.Property<int>("MeterID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Analog");

                    b.Property<int?>("Distance");

                    b.Property<string>("Label");

                    b.Property<int>("Resistance");

                    b.Property<int?>("Temperatuur");

                    b.Property<int>("Type");

                    b.Property<int?>("Vochtigheid");

                    b.Property<int>("Volgtage");

                    b.Property<int>("Voltage");

                    b.HasKey("MeterID");

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
