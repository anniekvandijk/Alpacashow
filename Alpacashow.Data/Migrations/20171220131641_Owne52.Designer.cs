﻿// <auto-generated />
using Alpacashow.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Alpacashow.Data.Migrations
{
    [DbContext(typeof(AlpacashowContext))]
    [Migration("20171220131641_Owne52")]
    partial class Owne52
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alpacashow.Data.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BreedId");

                    b.Property<string>("Chip")
                        .IsRequired();

                    b.Property<int>("ColorId");

                    b.Property<string>("Dam")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("Dob");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("OwnerId");

                    b.Property<int>("SexId");

                    b.Property<string>("Sire")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("AnimalId");

                    b.HasIndex("BreedId");

                    b.HasIndex("ColorId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("SexId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.AnimalOwner", b =>
                {
                    b.Property<int>("AnimalOwnerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnimalId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("OwnerId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("AnimalOwnerId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("OwnerId");

                    b.ToTable("AnimalOwners");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.Enums.AgeClass", b =>
                {
                    b.Property<int>("AgeClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("AgeClassId");

                    b.ToTable("AgeClasses");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.Enums.Breed", b =>
                {
                    b.Property<int>("BreedId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("BreedId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.Enums.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ColorId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.Enums.Sex", b =>
                {
                    b.Property<int>("SexId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("SexId");

                    b.ToTable("Sexes");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.Enums.ShowType", b =>
                {
                    b.Property<int>("ShowTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ShowTypeId");

                    b.ToTable("ShowTypes");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FarmName")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.ShowEvent", b =>
                {
                    b.Property<int>("ShowEventId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Judge")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ShowTypeId");

                    b.HasKey("ShowEventId");

                    b.HasIndex("ShowTypeId");

                    b.ToTable("ShowEvents");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.ShowEventAnimal", b =>
                {
                    b.Property<int>("AnimalId");

                    b.Property<int>("ShowEventId");

                    b.Property<int>("OwnerId");

                    b.HasKey("AnimalId", "ShowEventId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ShowEventId");

                    b.ToTable("ShowEventAnimals");
                });

            modelBuilder.Entity("Alpacashow.Data.Models.Animal", b =>
                {
                    b.HasOne("Alpacashow.Data.Models.Enums.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alpacashow.Data.Models.Enums.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alpacashow.Data.Models.Owner", "Owner")
                        .WithMany("Animals")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alpacashow.Data.Models.Enums.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alpacashow.Data.Models.AnimalOwner", b =>
                {
                    b.HasOne("Alpacashow.Data.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alpacashow.Data.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alpacashow.Data.Models.ShowEvent", b =>
                {
                    b.HasOne("Alpacashow.Data.Models.Enums.ShowType", "ShowType")
                        .WithMany()
                        .HasForeignKey("ShowTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alpacashow.Data.Models.ShowEventAnimal", b =>
                {
                    b.HasOne("Alpacashow.Data.Models.Animal", "Animal")
                        .WithMany("ShowEventAnimal")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alpacashow.Data.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alpacashow.Data.Models.ShowEvent", "ShowEvent")
                        .WithMany("ShowEventAnimal")
                        .HasForeignKey("ShowEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
