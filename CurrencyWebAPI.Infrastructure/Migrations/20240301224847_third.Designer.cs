﻿// <auto-generated />
using System;
using CurrencyWebAPI.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CurrencyWebAPI.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240301224847_third")]
    partial class third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CurrencyWebAPI.Domain.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AttributeName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CurrencyWebAPI.Domain.Entities.CurrencyDetail", b =>
                {
                    b.Property<int>("CurrencyId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME")
                        .HasColumnOrder(2);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnOrder(3);

                    b.HasKey("CurrencyId", "Date");

                    b.ToTable("CurrencyDetails");
                });

            modelBuilder.Entity("CurrencyWebAPI.Domain.Entities.CurrencyDetailDaily", b =>
                {
                    b.Property<int>("CurrencyId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME")
                        .HasColumnOrder(2);

                    b.Property<string>("AvarageValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnOrder(3);

                    b.Property<string>("MaxValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnOrder(4);

                    b.Property<string>("MinValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnOrder(5);

                    b.HasKey("CurrencyId", "Date");

                    b.ToTable("CurrencyDetailDailys");
                });

            modelBuilder.Entity("CurrencyWebAPI.Domain.Entities.CurrencyDetailHourly", b =>
                {
                    b.Property<int>("CurrencyId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME")
                        .HasColumnOrder(2);

                    b.Property<string>("AvarageValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnOrder(3);

                    b.Property<string>("MaxValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnOrder(4);

                    b.Property<string>("MinValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnOrder(5);

                    b.HasKey("CurrencyId", "Date");

                    b.ToTable("CurrencyDetailHourlys");
                });

            modelBuilder.Entity("CurrencyWebAPI.Domain.Entities.CurrencyDetail", b =>
                {
                    b.HasOne("CurrencyWebAPI.Domain.Entities.Currency", "Currency")
                        .WithMany("CurrencyDetials")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("CurrencyWebAPI.Domain.Entities.CurrencyDetailDaily", b =>
                {
                    b.HasOne("CurrencyWebAPI.Domain.Entities.Currency", "Currency")
                        .WithMany("CurrencyDetialDailys")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("CurrencyWebAPI.Domain.Entities.CurrencyDetailHourly", b =>
                {
                    b.HasOne("CurrencyWebAPI.Domain.Entities.Currency", "Currency")
                        .WithMany("CurrencyDetialHourlys")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("CurrencyWebAPI.Domain.Entities.Currency", b =>
                {
                    b.Navigation("CurrencyDetialDailys");

                    b.Navigation("CurrencyDetialHourlys");

                    b.Navigation("CurrencyDetials");
                });
#pragma warning restore 612, 618
        }
    }
}
