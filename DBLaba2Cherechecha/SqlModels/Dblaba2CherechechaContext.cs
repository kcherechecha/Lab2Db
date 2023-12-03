using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBLaba2Cherechecha.SqlModels;

public partial class Dblaba2CherechechaContext : DbContext
{
    public Dblaba2CherechechaContext()
    {
    }

    public Dblaba2CherechechaContext(DbContextOptions<Dblaba2CherechechaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=boda; Database=DBLaba2Cherechecha; Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movie__4BD2941A843CB8B7");

            entity.ToTable("Movie");

            entity.Property(e => e.MovieId).ValueGeneratedNever();
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.MovieName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MovieRating).HasColumnType("decimal(3, 1)");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79CE093D52C7");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).ValueGeneratedNever();
            entity.Property(e => e.FkMovieId).HasColumnName("FK_MovieId");
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.ReviewText).HasColumnType("text");

            entity.HasOne(d => d.FkMovie).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.FkMovieId)
                .HasConstraintName("FK__Review__FK_Movie__398D8EEE");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Session__C9F49290A9C891A8");

            entity.ToTable("Session");

            entity.Property(e => e.SessionId).ValueGeneratedNever();
            entity.Property(e => e.FkHallId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FK_HallId");
            entity.Property(e => e.FkMovieId).HasColumnName("FK_MovieId");
            entity.Property(e => e.FkSessionStatusId).HasColumnName("FK_SessionStatusId");
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.FkMovie).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.FkMovieId)
                .HasConstraintName("FK__Session__FK_Movi__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
