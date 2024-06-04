﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RamenGo_API_Data.Context;

#nullable disable

namespace RamenGo_API_Data.Migrations
{
    [DbContext(typeof(RamenContext))]
    [Migration("20240530203605_DBCreation")]
    partial class DBCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RamenGo_API_Domain.Entities.Broth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_creation");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageActive")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imageActive");

                    b.Property<string>("ImageInactive")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imageInactive");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_modification");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<string>("TypeStatus")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("tp_status");

                    b.HasKey("Id");

                    b.ToTable("tb_broth", (string)null);
                });

            modelBuilder.Entity("RamenGo_API_Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrothId")
                        .HasColumnType("integer")
                        .HasColumnName("brothId");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_creation");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_modification");

                    b.Property<int>("ProteinId")
                        .HasColumnType("integer")
                        .HasColumnName("proteinId");

                    b.Property<string>("TypeStatus")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("tp_status");

                    b.HasKey("Id");

                    b.HasIndex("BrothId");

                    b.HasIndex("ProteinId");

                    b.ToTable("tb_order", (string)null);
                });

            modelBuilder.Entity("RamenGo_API_Domain.Entities.Protein", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_creation");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageActive")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imageActive");

                    b.Property<string>("ImageInactive")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imageInactive");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_modification");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<string>("TypeStatus")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("tp_status");

                    b.HasKey("Id");

                    b.ToTable("tb_protein", (string)null);
                });

            modelBuilder.Entity("RamenGo_API_Domain.Entities.Order", b =>
                {
                    b.HasOne("RamenGo_API_Domain.Entities.Broth", "Broth")
                        .WithMany("Orders")
                        .HasForeignKey("BrothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RamenGo_API_Domain.Entities.Protein", "Protein")
                        .WithMany("Orders")
                        .HasForeignKey("ProteinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Broth");

                    b.Navigation("Protein");
                });

            modelBuilder.Entity("RamenGo_API_Domain.Entities.Broth", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RamenGo_API_Domain.Entities.Protein", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
