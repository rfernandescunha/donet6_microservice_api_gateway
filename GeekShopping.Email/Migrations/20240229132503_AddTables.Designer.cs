﻿// <auto-generated />
using System;
using GeekShopping.Email.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekShopping.Email.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20240229132503_AddTables")]
    partial class AddTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GeekShopping.Email.Domain.Entities.EmailLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("Log")
                        .HasColumnType("longtext")
                        .HasColumnName("log");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("send_date");

                    b.HasKey("Id");

                    b.ToTable("email_log");
                });
#pragma warning restore 612, 618
        }
    }
}
