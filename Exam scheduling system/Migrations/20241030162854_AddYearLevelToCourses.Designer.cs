﻿// <auto-generated />
using System;
using ExamSchedulingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamSchedulingSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241030162854_AddYearLevelToCourses")]
    partial class AddYearLevelToCourses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExamSchedulingSystem.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseDepartment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("course_department");

                    b.Property<string>("CourseName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("course_name");

                    b.Property<int?>("PrerequestId")
                        .HasColumnType("int")
                        .HasColumnName("prerequest_id");

                    b.Property<int>("YearLevel")
                        .HasColumnType("int")
                        .HasColumnName("year_level");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.ClassRoom", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.HasKey("RoomId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.Coordinator", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Coordinators");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.Invigilator", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Invigilators");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.Student", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.Teacher", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.Coordinator", b =>
                {
                    b.HasOne("Examschedulingsystem.Models.User", "User")
                        .WithMany("Coordinators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.Invigilator", b =>
                {
                    b.HasOne("Examschedulingsystem.Models.User", "User")
                        .WithMany("Invigilators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.Student", b =>
                {
                    b.HasOne("Examschedulingsystem.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("Examschedulingsystem.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.Teacher", b =>
                {
                    b.HasOne("Examschedulingsystem.Models.User", "User")
                        .WithMany("Teachers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Examschedulingsystem.Models.User", b =>
                {
                    b.Navigation("Coordinators");

                    b.Navigation("Invigilators");

                    b.Navigation("Student");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
