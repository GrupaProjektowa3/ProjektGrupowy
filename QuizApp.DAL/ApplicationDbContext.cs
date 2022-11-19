﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<LoggedInUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Question>()
                .HasMany(c => c.Answers)
                .WithOne(x => x.Question)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Quizzes)
                .WithOne(x => x.Category)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Images)
                .WithOne(x => x.Category)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quiz>()
            .HasMany(c => c.Questions)
            .WithOne(x => x.Quiz)
    .       OnDelete(DeleteBehavior.Cascade);

        }

    }
}
