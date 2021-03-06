﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BAMTriviaProject2.DAL
{
    public partial class BAMTriviaProject2Context : DbContext
    {
        public BAMTriviaProject2Context()
        {
        }

        public BAMTriviaProject2Context(DbContextOptions<BAMTriviaProject2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<QuizQuestions> QuizQuestions { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Tusers> Tusers { get; set; }
        public virtual DbSet<UserQuizzes> UserQuizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Answers__C6900628CBCCB1EC");

                entity.ToTable("Answers", "TP2");

                entity.Property(e => e.Aid).HasColumnName("AId");

                entity.Property(e => e.Aanswer)
                    .IsRequired()
                    .HasColumnName("AAnswer")
                    .HasMaxLength(500);

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.HasOne(d => d.Q)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Qid);
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.Qid)
                    .HasName("PK__Question__CAB1462BD028E95B");

                entity.ToTable("Questions", "TP2");

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.Property(e => e.QaverageReview)
                    .HasColumnName("QAverageReview")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Qcategory)
                    .IsRequired()
                    .HasColumnName("QCategory")
                    .HasMaxLength(100);

                entity.Property(e => e.Qrating)
                    .HasColumnName("QRating")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Qstring)
                    .IsRequired()
                    .HasColumnName("QString")
                    .HasMaxLength(300);

                entity.Property(e => e.Qtype)
                    .IsRequired()
                    .HasColumnName("QType")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('Multiple')");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz", "TP2");

                entity.Property(e => e.QuizCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.QuizDifficulty).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<QuizQuestions>(entity =>
            {
                entity.HasKey(e => new { e.QuizId, e.Qid })
                    .HasName("PK__QuizResu__27E9BAEC415575D4");

                entity.ToTable("QuizQuestions", "TP2");

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.HasOne(d => d.Q)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.Qid)
                    .HasConstraintName("FK_QuizResults_Questions_QId");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_QuizResults_Quiz_QuizId");
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasKey(e => e.ResultId)
                    .HasName("PK__Results__976902081729FF21");

                entity.ToTable("Results", "TP2");

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.Property(e => e.UserAnswer).HasMaxLength(300);

                entity.HasOne(d => d.Q)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.Qid);

                entity.HasOne(d => d.UserQuiz)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.UserQuizId);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PK__Reviews__CAFF40D2E5A1B5B8");

                entity.ToTable("Reviews", "TP2");

                entity.Property(e => e.Rid).HasColumnName("RId");

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.Property(e => e.Rratings).HasColumnName("RRatings");

                entity.HasOne(d => d.Q)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Qid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Reviews_Question_QId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Reviews_User_UserId");
            });

            modelBuilder.Entity<Tusers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TUsers__1788CC4C528980D4");

                entity.ToTable("TUsers", "TP2");

                entity.HasIndex(e => e.CreditCardNumber)
                    .HasName("UQ__TUsers__315DB9250FFB5DA5")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__TUsers__536C85E4D8F7F2FD")
                    .IsUnique();

                entity.Property(e => e.AccountType).HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Pw)
                    .IsRequired()
                    .HasColumnName("PW")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserQuizzes>(entity =>
            {
                entity.HasKey(e => e.UserQuizId)
                    .HasName("PK__UserQuiz__20FA6387CF94E6DD");

                entity.ToTable("UserQuizzes", "TP2");

                entity.Property(e => e.QuizDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_UserQuizes_Quiz_QuizId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserQuizes_User_UserId");
            });
        }
    }
}
