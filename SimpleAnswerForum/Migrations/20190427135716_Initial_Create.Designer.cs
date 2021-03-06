﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SimpleAnswerForum.Data;
using System;

namespace SimpleAnswerForum.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190427135716_Initial_Create")]
    partial class Initial_Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Content")
                        .HasMaxLength(140);

                    b.Property<long>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Bio")
                        .HasMaxLength(256);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Credentials")
                        .HasMaxLength(128);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePictureFilename");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.DownvoteAnswer", b =>
                {
                    b.Property<long>("AnswerId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<long>("Id");

                    b.HasKey("AnswerId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("DownvoteAnswer");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.DownvoteQuestion", b =>
                {
                    b.Property<long>("QuestionId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<long>("Id");

                    b.HasKey("QuestionId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("DownvoteQuestion");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Content")
                        .HasMaxLength(140);

                    b.Property<long?>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("TopicId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.Topic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.TopicQuestion", b =>
                {
                    b.Property<long>("TopicId");

                    b.Property<long>("QuestionId");

                    b.Property<long>("Id");

                    b.HasKey("TopicId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("TopicQuestion");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.UpvoteAnswer", b =>
                {
                    b.Property<long>("AnswerId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<long>("Id");

                    b.HasKey("AnswerId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UpvoteAnswer");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.UpvoteQuestion", b =>
                {
                    b.Property<long>("QuestionId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<long>("Id");

                    b.HasKey("QuestionId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UpvoteQuestion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.Answer", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Answers")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("SimpleAnswerForum.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.DownvoteAnswer", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.Answer", "Answer")
                        .WithMany("DownvoteAnswers")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("DownvoteAnswers")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.DownvoteQuestion", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("DownvoteQuestions")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleAnswerForum.Models.Question", "Question")
                        .WithMany("DownvoteQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.Question", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Questions")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("SimpleAnswerForum.Models.Topic")
                        .WithMany("Questions")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.TopicQuestion", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.Question", "Question")
                        .WithMany("TopicQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleAnswerForum.Models.Topic", "Topic")
                        .WithMany("TopicQuestions")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.UpvoteAnswer", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.Answer", "Answer")
                        .WithMany("UpvoteAnswers")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UpvoteAnswers")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleAnswerForum.Models.UpvoteQuestion", b =>
                {
                    b.HasOne("SimpleAnswerForum.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UpvoteQuestions")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleAnswerForum.Models.Question", "Question")
                        .WithMany("UpvoteQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
