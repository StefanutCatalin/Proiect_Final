﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Final.Data;

#nullable disable

namespace Proiect_Final.Migrations
{
    [DbContext(typeof(Proiect_FinalContext))]
    [Migration("20230102104545_Structura")]
    partial class Structura
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Final.Models.Angajat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Angajat");
                });

            modelBuilder.Entity("Proiect_Final.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Proiect_Final.Models.CategorieMancare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("RezervareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("RezervareID");

                    b.ToTable("CategorieMancare");
                });

            modelBuilder.Entity("Proiect_Final.Models.Chelner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeChelner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Chelner");
                });

            modelBuilder.Entity("Proiect_Final.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Proiect_Final.Models.Rezervare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ChelnerID")
                        .HasColumnType("int");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataRezervare")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumarPersoane")
                        .HasColumnType("int");

                    b.Property<string>("NumeRestaurant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ChelnerID");

                    b.HasIndex("ClientID");

                    b.ToTable("Rezervare");
                });

            modelBuilder.Entity("Proiect_Final.Models.Structura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AngajatID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataRezervare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Masa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RezervareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AngajatID");

                    b.HasIndex("RezervareID");

                    b.ToTable("Structura");
                });

            modelBuilder.Entity("Proiect_Final.Models.CategorieMancare", b =>
                {
                    b.HasOne("Proiect_Final.Models.Categorie", "Categorie")
                        .WithMany("CategoriiMancare")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Final.Models.Rezervare", "Rezervare")
                        .WithMany("CategoriiMancare")
                        .HasForeignKey("RezervareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Rezervare");
                });

            modelBuilder.Entity("Proiect_Final.Models.Rezervare", b =>
                {
                    b.HasOne("Proiect_Final.Models.Chelner", "Chelner")
                        .WithMany("Rezervari")
                        .HasForeignKey("ChelnerID");

                    b.HasOne("Proiect_Final.Models.Client", "Client")
                        .WithMany("Rezervari")
                        .HasForeignKey("ClientID");

                    b.Navigation("Chelner");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Proiect_Final.Models.Structura", b =>
                {
                    b.HasOne("Proiect_Final.Models.Angajat", "Angajat")
                        .WithMany("structuri")
                        .HasForeignKey("AngajatID");

                    b.HasOne("Proiect_Final.Models.Rezervare", "Rezervare")
                        .WithMany()
                        .HasForeignKey("RezervareID");

                    b.Navigation("Angajat");

                    b.Navigation("Rezervare");
                });

            modelBuilder.Entity("Proiect_Final.Models.Angajat", b =>
                {
                    b.Navigation("structuri");
                });

            modelBuilder.Entity("Proiect_Final.Models.Categorie", b =>
                {
                    b.Navigation("CategoriiMancare");
                });

            modelBuilder.Entity("Proiect_Final.Models.Chelner", b =>
                {
                    b.Navigation("Rezervari");
                });

            modelBuilder.Entity("Proiect_Final.Models.Client", b =>
                {
                    b.Navigation("Rezervari");
                });

            modelBuilder.Entity("Proiect_Final.Models.Rezervare", b =>
                {
                    b.Navigation("CategoriiMancare");
                });
#pragma warning restore 612, 618
        }
    }
}