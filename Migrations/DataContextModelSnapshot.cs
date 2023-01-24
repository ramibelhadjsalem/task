﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task.Data;

#nullable disable

namespace task.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("task.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("game")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("platforms")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("playTime")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
