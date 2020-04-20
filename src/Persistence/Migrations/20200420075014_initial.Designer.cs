﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200420075014_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Domain.DefaultCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DefaultCustomer");
                });

            modelBuilder.Entity("Domain.DefaultProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DefaultCustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LicensesTotal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DefaultCustomerId");

                    b.ToTable("DefaultProduct");
                });

            modelBuilder.Entity("Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<int>("LicensesTotal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DefaultProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DefaultProductId");

                    b.HasIndex("MovieId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Domain.Studio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("Domain.Trivia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DefaultProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DefaultProductId");

                    b.HasIndex("MovieId");

                    b.ToTable("Trivia");
                });

            modelBuilder.Entity("Domain.DefaultProduct", b =>
                {
                    b.HasOne("Domain.DefaultCustomer", null)
                        .WithMany("Procucts")
                        .HasForeignKey("DefaultCustomerId");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.HasOne("Domain.DefaultCustomer", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.DefaultProduct", null)
                        .WithMany("Reviews")
                        .HasForeignKey("DefaultProductId");

                    b.HasOne("Domain.Movie", null)
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("Domain.Trivia", b =>
                {
                    b.HasOne("Domain.DefaultProduct", null)
                        .WithMany("Trivias")
                        .HasForeignKey("DefaultProductId");

                    b.HasOne("Domain.Movie", "Movie")
                        .WithMany("Trivias")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}