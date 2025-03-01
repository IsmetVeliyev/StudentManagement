﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Context;

#nullable disable

namespace StudentManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240901175524_n")]
    partial class n
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudentManagement.Models.Course", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonId"), 1L, 1);

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<double>("Hours")
                        .HasColumnType("float");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("teacherpassaportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LessonId");

                    b.HasIndex("teacherpassaportNumber");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("StudentManagement.Models.Student", b =>
                {
                    b.Property<string>("studentNum")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studentNum");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagement.Models.Teacher", b =>
                {
                    b.Property<string>("passaportNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("passaportNumber");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentManagement.Models.User", b =>
                {
                    b.Property<string>("gmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("gmail");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentManagement.Models.Course", b =>
                {
                    b.HasOne("StudentManagement.Models.Teacher", "teacher")
                        .WithMany()
                        .HasForeignKey("teacherpassaportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
