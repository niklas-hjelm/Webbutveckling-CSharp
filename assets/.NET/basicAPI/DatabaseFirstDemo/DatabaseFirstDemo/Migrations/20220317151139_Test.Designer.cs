﻿// <auto-generated />
using System;
using DatabaseFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseFirstDemo.Migrations
{
    [DbContext(typeof(HeroSchoolContext))]
    [Migration("20220317151139_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DatabaseFirstDemo.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DatabaseFirstDemo.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentPlan", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId")
                        .HasName("PK_StudentPlan");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentPlans", (string)null);
                });

            modelBuilder.Entity("StudentPlan", b =>
                {
                    b.HasOne("DatabaseFirstDemo.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_CourseId_Courses");

                    b.HasOne("DatabaseFirstDemo.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_StudentId_Students");
                });
#pragma warning restore 612, 618
        }
    }
}
