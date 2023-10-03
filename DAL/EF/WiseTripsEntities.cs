using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class WiseTripsEntities : DbContext
{
    public WiseTripsEntities()
    {
    }

    public WiseTripsEntities(DbContextOptions<WiseTripsEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=WiseTrips;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agencies__3214EC07A420C08E");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Agencies)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Agencies_Users");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coupons__3214EC07FA56E7C8");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExpireOn).HasColumnType("datetime");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.AddedBy)
                .HasConstraintName("FK_Coupons_Users");

            entity.HasOne(d => d.SponsoredByNavigation).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.SponsoredBy)
                .HasConstraintName("FK_Coupons_Agencies");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hotels__3214EC071B52EFBC");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logs__3214EC07F67685D8");

            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NewEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NewPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NewUsername)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldUsername)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Logs_Users");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Packages__3214EC07999663E1");

            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Details).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Agency).WithMany(p => p.Packages)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Packages_Agencies");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC077B149631");

            entity.Property(e => e.AddedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Roles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Roles_Users");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tokens__3214EC07FD3E04D4");

            entity.Property(e => e.AuthToken)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiredOn).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tokens_Users");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trips__3214EC07EFC27CEF");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Trips)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trips_Hotels");

            entity.HasOne(d => d.Package).WithMany(p => p.Trips)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Histories_Packages");

            entity.HasOne(d => d.UsedCouponNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.UsedCoupon)
                .HasConstraintName("FK_Histories_Coupons");

            entity.HasOne(d => d.User).WithMany(p => p.Trips)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Histories_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07702A63C2");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegisteredOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Sex)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
