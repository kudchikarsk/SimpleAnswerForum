using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleAnswerForum.Data.Models;
using SimpleAnswerForum.Models;

namespace SimpleAnswerForum.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            //Topic Question
            builder.Entity<TopicQuestion>()
            .HasKey(bc => new { bc.TopicId, bc.QuestionId });

            builder.Entity<TopicQuestion>()
                .HasIndex(tq => new { tq.TopicId, tq.QuestionId })
                .IsUnique();

            builder.Entity<TopicQuestion>()
                .HasOne(tq => tq.Topic)
                .WithMany(t => t.TopicQuestions)
                .HasForeignKey(tq => tq.TopicId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TopicQuestion>()
                .HasOne(tq => tq.Question)
                .WithMany(q => q.TopicQuestions)
                .HasForeignKey(tq => tq.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Upvote Question
            builder.Entity<UpvoteQuestion>()
           .HasKey(uq => new { uq.QuestionId, uq.ApplicationUserId });

            builder.Entity<UpvoteQuestion>()
                .HasIndex(uq => new { uq.ApplicationUserId, uq.QuestionId })
                .IsUnique();

            builder.Entity<UpvoteQuestion>()
                .HasOne(uq => uq.Question)
                .WithMany(q => q.UpvoteQuestions)
                .HasForeignKey(uq => uq.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UpvoteQuestion>()
                .HasOne(uq => uq.ApplicationUser)
                .WithMany(q => q.UpvoteQuestions)
                .HasForeignKey(uq => uq.ApplicationUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Downvote Question
            builder.Entity<DownvoteQuestion>()
           .HasKey(dq => new { dq.QuestionId, dq.ApplicationUserId });

            builder.Entity<DownvoteQuestion>()
                .HasIndex(dq => new { dq.ApplicationUserId, dq.QuestionId })
                .IsUnique();

            builder.Entity<DownvoteQuestion>()
                .HasOne(dq => dq.Question)
                .WithMany(q => q.DownvoteQuestions)
                .HasForeignKey(dq => dq.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DownvoteQuestion>()
                .HasOne(dq => dq.ApplicationUser)
                .WithMany(q => q.DownvoteQuestions)
                .HasForeignKey(dq => dq.ApplicationUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            //Upvote Answer
            builder.Entity<UpvoteAnswer>()
           .HasKey(ua => new { ua.AnswerId, ua.ApplicationUserId });

            builder.Entity<UpvoteAnswer>()
                .HasIndex(ua => new { ua.ApplicationUserId, ua.AnswerId })
                .IsUnique();

            builder.Entity<UpvoteAnswer>()
                .HasOne(ua => ua.Answer)
                .WithMany(a => a.UpvoteAnswers)
                .HasForeignKey(uq => uq.AnswerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UpvoteAnswer>()
                .HasOne(uq => uq.ApplicationUser)
                .WithMany(q => q.UpvoteAnswers)
                .HasForeignKey(uq => uq.ApplicationUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Downvote Answer
            builder.Entity<DownvoteAnswer>()
           .HasKey(dq => new { dq.AnswerId, dq.ApplicationUserId });

            builder.Entity<DownvoteAnswer>()
                .HasIndex(da => new { da.ApplicationUserId, da.AnswerId })
                .IsUnique();

            builder.Entity<DownvoteAnswer>()
                .HasOne(dq => dq.Answer)
                .WithMany(q => q.DownvoteAnswers)
                .HasForeignKey(dq => dq.AnswerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DownvoteAnswer>()
                .HasOne(dq => dq.ApplicationUser)
                .WithMany(q => q.DownvoteAnswers)
                .HasForeignKey(dq => dq.ApplicationUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<SimpleAnswerForum.Data.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<SimpleAnswerForum.Data.Models.Question> Question { get; set; }

        public DbSet<SimpleAnswerForum.Data.Models.Answer> Answer { get; set; }

        public DbSet<SimpleAnswerForum.Data.Models.UpvoteQuestion> UpvoteQuestion { get; set; }

        public DbSet<SimpleAnswerForum.Data.Models.DownvoteQuestion> DownvoteQuestion { get; set; }

        public DbSet<SimpleAnswerForum.Data.Models.UpvoteAnswer> UpvoteAnswer { get; set; }

        public DbSet<SimpleAnswerForum.Data.Models.DownvoteAnswer> DownvoteAnswer { get; set; }

        public DbSet<SimpleAnswerForum.Data.Models.Topic> Topic { get; set; }
    }
}
