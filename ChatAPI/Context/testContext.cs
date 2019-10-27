using System;
using ChatAPI.Models.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChatAPI.Context
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caisse> Caisse { get; set; }
        public virtual DbSet<Journee> Journee { get; set; }
        public virtual DbSet<JourneeDetail> JourneeDetail { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Mois> Mois { get; set; }
        public virtual DbSet<Todo> Todo { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.1.16\\TEST;Database=test;User Id=sa;Password=5n-cVu;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Caisse>(entity =>
            {
                entity.HasKey(e => e.IdCaisse);

                entity.Property(e => e.DateDebut).HasColumnType("datetime");

                entity.Property(e => e.DateFin).HasColumnType("datetime");

                entity.Property(e => e.PrixFinal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrixUnit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdMoisNavigation)
                    .WithMany(p => p.Caisse)
                    .HasForeignKey(d => d.IdMois)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caisse_Mois");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Caisse)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caisse_Users");
            });

            modelBuilder.Entity<Journee>(entity =>
            {
                entity.HasKey(e => e.IdJournee);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Prix).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCaisseNavigation)
                    .WithMany(p => p.Journee)
                    .HasForeignKey(d => d.IdCaisse)
                    .HasConstraintName("FK_Journee_Caisse");
            });

            modelBuilder.Entity<JourneeDetail>(entity =>
            {
                entity.HasKey(e => e.IdJourneeDetail);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Motif)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prix).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdJourneeNavigation)
                    .WithMany(p => p.JourneeDetail)
                    .HasForeignKey(d => d.IdJournee)
                    .HasConstraintName("FK_JourneeDetail_Journee1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.JourneeDetail)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JourneeDetail_Users");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.IdMessage);

                entity.Property(e => e.DatTime).HasColumnType("date");

                entity.Property(e => e.MessageContent)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Message_Users");
            });

            modelBuilder.Entity<Mois>(entity =>
            {
                entity.HasKey(e => e.IdMois);

                entity.Property(e => e.NameMois)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.IdTodo);

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.Property(e => e.Prix).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TodoName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tokens)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
