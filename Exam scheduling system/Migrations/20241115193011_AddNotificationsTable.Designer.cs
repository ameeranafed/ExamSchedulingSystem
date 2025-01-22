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
    [Migration("20241115193011_AddNotificationsTable")]
    partial class AddNotificationsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExamSchedulingSystem.Models.ChangeRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<string>("CoordinatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("RequestText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.HasIndex("ReservationId");

                    b.ToTable("ChangeRequests");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.ClassRoom", b =>
                {
                    b.Property<string>("RoomId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("room_id");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.HasKey("RoomId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Coordinator", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Coordinators");
                });

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

            modelBuilder.Entity("ExamSchedulingSystem.Models.ExamReservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reservation_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<string>("CoordinatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("coordinator_id");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("course_name");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("end_time");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("exam_date");

                    b.Property<string>("ExamType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("exam_type");

                    b.Property<string>("InvigilatorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("invigilator_name");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("room_id");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("start_time");

                    b.HasKey("ReservationId");

                    b.HasIndex("CoordinatorId");

                    b.HasIndex("CourseId");

                    b.HasIndex("RoomId");

                    b.ToTable("ExamReservations");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.ExamSchedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("schedule_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("course_name");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("end_time");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("exam_date");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("place");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("start_time");

                    b.HasKey("ScheduleId");

                    b.HasIndex("CourseId");

                    b.ToTable("ExamSchedules");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Excuse", b =>
                {
                    b.Property<int>("ExcuseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExcuseId"));

                    b.Property<string>("CoordinatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExcuseText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvigilatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("ExcuseId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Excuses");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Invigilator", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Invigilators");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Lecture", b =>
                {
                    b.Property<int>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("lecture_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectureId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("room_id");

                    b.Property<int>("SlotId")
                        .HasColumnType("int")
                        .HasColumnName("slot_id");

                    b.HasKey("LectureId");

                    b.HasIndex("CourseId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SlotId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NotificationId");

                    b.HasIndex("RecipientId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Student", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Teacher", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.TimeSlot", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("slot_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SlotId"));

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("day");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("end_time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("start_time");

                    b.HasKey("SlotId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.User", b =>
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

            modelBuilder.Entity("ExamSchedulingSystem.Models.ChangeRequest", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.ExamReservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Coordinator", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.User", "User")
                        .WithMany("Coordinators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.ExamReservation", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.User", "Coordinator")
                        .WithMany()
                        .HasForeignKey("CoordinatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamSchedulingSystem.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamSchedulingSystem.Models.ClassRoom", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinator");

                    b.Navigation("Course");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.ExamSchedule", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Excuse", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.ExamReservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Invigilator", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.User", "User")
                        .WithMany("Invigilators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Lecture", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamSchedulingSystem.Models.ClassRoom", "Classroom")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamSchedulingSystem.Models.TimeSlot", "TimeSlot")
                        .WithMany()
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Course");

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Notification", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Student", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("ExamSchedulingSystem.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.Teacher", b =>
                {
                    b.HasOne("ExamSchedulingSystem.Models.User", "User")
                        .WithMany("Teachers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamSchedulingSystem.Models.User", b =>
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
