using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExosFC.Models
{
    public partial class ExodusKnightsContext : DbContext
    {
        public ExodusKnightsContext()
        {
        }

        public ExodusKnightsContext(DbContextOptions<ExodusKnightsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobBid> JobBid { get; set; }
        public virtual DbSet<JobRequest> JobRequest { get; set; }
        public virtual DbSet<RequestedItem> RequestedItem { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-K9ALEKD;Database=ExodusKnights;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobBid>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.HasOne(d => d.FkJobRequestNavigation)
                    .WithMany(p => p.JobBid)
                    .HasForeignKey(d => d.FkJobRequest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobBid_JobRequest");

                entity.HasOne(d => d.FkUserB)
                    .WithMany(p => p.JobBid)
                    .HasForeignKey(d => d.FkUserBid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobBid_User");
            });

            modelBuilder.Entity<JobRequest>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DatePosted).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkBidAcceptedNavigation)
                    .WithMany(p => p.JobRequest)
                    .HasForeignKey(d => d.FkBidAccepted)
                    .HasConstraintName("FK_JobRequest_JobBid");

                entity.HasOne(d => d.FkUserPostedNavigation)
                    .WithMany(p => p.JobRequest)
                    .HasForeignKey(d => d.FkUserPosted)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobRequest_User");
            });

            modelBuilder.Entity<RequestedItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemId)
                    .IsRequired()
                    .HasColumnName("ItemID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkJobRequestNavigation)
                    .WithMany(p => p.RequestedItem)
                    .HasForeignKey(d => d.FkJobRequest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestedItem_JobRequest");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsVerified).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });
        }
    }
}
