using EntitiesLayer.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<CATEGORy> CATEGORIES { get; set; }
        public virtual DbSet<CHOICE> CHOICES { get; set; }
        public virtual DbSet<DIFFICULTy> DIFFICULTIES { get; set; }
        public virtual DbSet<GAME_QUESTIONS> GAME_QUESTIONS { get; set; }
        public virtual DbSet<GAME_SESSIONS> GAME_SESSIONS { get; set; }
        public virtual DbSet<QUESTION> QUESTIONS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USER_TYPES> USER_TYPES { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
        public DbSet<USER_STATISTICS> UserStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORy>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORy>()
                .HasMany(e => e.QUESTIONS)
                .WithRequired(e => e.CATEGORy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CHOICE>()
                .Property(e => e.choiceText)
                .IsUnicode(false);

            modelBuilder.Entity<DIFFICULTy>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<DIFFICULTy>()
                .HasMany(e => e.QUESTIONS)
                .WithRequired(e => e.DIFFICULTy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GAME_SESSIONS>()
                .Property(e => e.gameMode)
                .IsUnicode(false);

            modelBuilder.Entity<GAME_SESSIONS>()
                .HasMany(e => e.GAME_QUESTIONS)
                .WithRequired(e => e.GAME_SESSIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.question)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.correctAnswer)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.incorrectAnswer1)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.incorrectAnswer2)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .Property(e => e.incorrectAnswer3)
                .IsUnicode(false);

            modelBuilder.Entity<QUESTION>()
                .HasMany(e => e.GAME_QUESTIONS)
                .WithRequired(e => e.QUESTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_TYPES>()
                .Property(e => e.userType)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TYPES>()
                .HasMany(e => e.USERS)
                .WithRequired(e => e.USER_TYPES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.GAME_SESSIONS)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);
        }
    }
}
