﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using e08.infrastructure;

#nullable disable

namespace e08.Migrations
{
    [DbContext(typeof(CountryTimeDBContext))]
    [Migration("20230210000327_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("e08.domain.CityTime", b =>
                {
                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeZone")
                        .HasColumnType("TEXT");

                    b.HasKey("City");

                    b.ToTable("CityTimes");
                });
#pragma warning restore 612, 618
        }
    }
}