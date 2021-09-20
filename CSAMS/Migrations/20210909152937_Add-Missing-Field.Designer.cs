﻿// <auto-generated />
using System;
using CSAMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSAMS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210909152937_Add-Missing-Field")]
    partial class AddMissingField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("CSAMS.Models.Assignments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Created")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReviewDeadline")
                        .HasColumnType("datetime2");

                    b.Property<byte>("ReviewEnabled")
                        .HasMaxLength(1)
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReviewID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("Reviewers")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubmissionID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("ReviewID");

                    b.HasIndex("SubmissionID");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("CSAMS.Models.Courses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseCode")
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CourseName")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hash")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Semester")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Teacher")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("Teacher");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CSAMS.Models.Fields", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Choices")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("FormID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("HasComment")
                        .HasMaxLength(1)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Priority")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("Required")
                        .HasMaxLength(1)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Weight")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FormID");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("CSAMS.Models.Forms", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Created")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Prefix")
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.HasKey("ID");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("CSAMS.Models.PeerReviews", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignmentID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReviewUserID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AssignmentID");

                    b.HasIndex("ReviewUserID");

                    b.HasIndex("UserID");

                    b.ToTable("PeerReviews");
                });

            modelBuilder.Entity("CSAMS.Models.Reviews", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("FormID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FormID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CSAMS.Models.Roles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CSAMS.Models.Submissions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("FormID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FormID");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("CSAMS.Models.UserCourses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("UserID");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("CSAMS.Models.UserReviews", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<int>("AssignmentID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReviewID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("UserReviewer")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserTarget")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AssignmentID");

                    b.HasIndex("ReviewID");

                    b.HasIndex("UserReviewer");

                    b.HasIndex("UserTarget");

                    b.ToTable("UserReviews");
                });

            modelBuilder.Entity("CSAMS.Models.UserSubmissions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<int>("AssignmentID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubmissionID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("UserID")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AssignmentID");

                    b.HasIndex("SubmissionID");

                    b.HasIndex("UserID");

                    b.ToTable("UserSubmissions");
                });

            modelBuilder.Entity("CSAMS.Models.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasMaxLength(11)
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("Role");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CSAMS.Models.Assignments", b =>
                {
                    b.HasOne("CSAMS.Models.Courses", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Reviews", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Submissions", "Submission")
                        .WithMany()
                        .HasForeignKey("SubmissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Review");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("CSAMS.Models.Courses", b =>
                {
                    b.HasOne("CSAMS.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("Teacher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CSAMS.Models.Fields", b =>
                {
                    b.HasOne("CSAMS.Models.Forms", "Form")
                        .WithMany()
                        .HasForeignKey("FormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("CSAMS.Models.PeerReviews", b =>
                {
                    b.HasOne("CSAMS.Models.Assignments", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Users", "ReviewUser")
                        .WithMany()
                        .HasForeignKey("ReviewUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("ReviewUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CSAMS.Models.Reviews", b =>
                {
                    b.HasOne("CSAMS.Models.Forms", "Form")
                        .WithMany()
                        .HasForeignKey("FormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("CSAMS.Models.Submissions", b =>
                {
                    b.HasOne("CSAMS.Models.Forms", "Form")
                        .WithMany()
                        .HasForeignKey("FormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("CSAMS.Models.UserCourses", b =>
                {
                    b.HasOne("CSAMS.Models.Courses", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CSAMS.Models.UserReviews", b =>
                {
                    b.HasOne("CSAMS.Models.Assignments", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Reviews", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Users", "Reviewer")
                        .WithMany()
                        .HasForeignKey("UserReviewer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Users", "Target")
                        .WithMany()
                        .HasForeignKey("UserTarget")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Review");

                    b.Navigation("Reviewer");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("CSAMS.Models.UserSubmissions", b =>
                {
                    b.HasOne("CSAMS.Models.Assignments", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Submissions", "Submission")
                        .WithMany()
                        .HasForeignKey("SubmissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSAMS.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Submission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CSAMS.Models.Users", b =>
                {
                    b.HasOne("CSAMS.Models.Roles", "UserRole")
                        .WithMany()
                        .HasForeignKey("Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
