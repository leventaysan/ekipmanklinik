﻿// <auto-generated />
using System;
using HastaneEkipman.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HastaneEkipman.Migrations
{
    [DbContext(typeof(APIDBContext))]
    [Migration("20200328133150_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HastaneEkipman.Models.Ekipman", b =>
                {
                    b.Property<int>("EkipmanID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EkipmanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EkipmanNumber")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("EkipmanProcDate")
                        .HasColumnType("Date");

                    b.Property<string>("EkipmanUnitPrice")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EkipmanUsageRate")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("KlinikID");

                    b.HasKey("EkipmanID");

                    b.ToTable("Ekipmans");
                });

            modelBuilder.Entity("HastaneEkipman.Models.Klinik", b =>
                {
                    b.Property<int>("KlinikID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KlinikName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KlinikID");

                    b.ToTable("Kliniks");
                });
#pragma warning restore 612, 618
        }
    }
}