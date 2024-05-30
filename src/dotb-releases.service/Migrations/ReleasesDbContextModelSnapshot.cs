﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotb.releases.repository;

#nullable disable

namespace dotbreleases.service.Migrations
{
    [DbContext(typeof(ReleasesDbContext))]
    partial class ReleasesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComponentStoreReleaseStore", b =>
                {
                    b.Property<int>("ComponentsId")
                        .HasColumnType("int");

                    b.Property<int>("ReleasesId")
                        .HasColumnType("int");

                    b.HasKey("ComponentsId", "ReleasesId");

                    b.HasIndex("ReleasesId");

                    b.ToTable("ComponentStoreReleaseStore");
                });

            modelBuilder.Entity("dotb.releases.repository.ComponentStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ComponentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Key")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Meta1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SystemsStoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SystemsStoreId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("dotb.releases.repository.ReleaseStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("Environment")
                        .HasColumnType("int");

                    b.Property<Guid>("Key")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Meta1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meta2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReleaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("dotb.releases.repository.SystemsStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExternalIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Key")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Meta1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meta2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("ComponentStoreReleaseStore", b =>
                {
                    b.HasOne("dotb.releases.repository.ComponentStore", null)
                        .WithMany()
                        .HasForeignKey("ComponentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotb.releases.repository.ReleaseStore", null)
                        .WithMany()
                        .HasForeignKey("ReleasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dotb.releases.repository.ComponentStore", b =>
                {
                    b.HasOne("dotb.releases.repository.SystemsStore", null)
                        .WithMany("Components")
                        .HasForeignKey("SystemsStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dotb.releases.repository.SystemsStore", b =>
                {
                    b.Navigation("Components");
                });
#pragma warning restore 612, 618
        }
    }
}