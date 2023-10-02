﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperHeroAPI.Data;

#nullable disable

namespace SuperHeroAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SuperHeroAPI.Models.Backpack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperHeroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuperHeroId")
                        .IsUnique();

                    b.ToTable("Backpacks");
                });

            modelBuilder.Entity("SuperHeroAPI.Models.SuperHero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SuperHeroes");
                });

            modelBuilder.Entity("SuperHeroAPI.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperHeroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuperHeroId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("SuperHeroAPI.Models.Backpack", b =>
                {
                    b.HasOne("SuperHeroAPI.Models.SuperHero", "SuperHero")
                        .WithOne("Backpack")
                        .HasForeignKey("SuperHeroAPI.Models.Backpack", "SuperHeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SuperHero");
                });

            modelBuilder.Entity("SuperHeroAPI.Models.Weapon", b =>
                {
                    b.HasOne("SuperHeroAPI.Models.SuperHero", "SuperHero")
                        .WithMany("Weapons")
                        .HasForeignKey("SuperHeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SuperHero");
                });

            modelBuilder.Entity("SuperHeroAPI.Models.SuperHero", b =>
                {
                    b.Navigation("Backpack");

                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
