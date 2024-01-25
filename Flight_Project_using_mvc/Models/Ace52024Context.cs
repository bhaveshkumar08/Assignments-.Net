using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BBookingDetail> BBookingDetails { get; set; }

    public virtual DbSet<BCustomer> BCustomers { get; set; }

    public virtual DbSet<BFlight> BFlights { get; set; }

    public virtual DbSet<BLocation> BLocations { get; set; }

    public virtual DbSet<Badmin> Badmins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BBookingDetail>(entity =>
        {
            entity.HasKey(e => new { e.BookingId, e.FlightId }).HasName("PK__B_Bookin__8B3CFB8520975F46");

            entity.ToTable("B_BookingDetails");

            entity.Property(e => e.BookingId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BookingID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FlightType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.BBookingDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__B_Booking__Custo__095F58DF");

            entity.HasOne(d => d.Flight).WithMany(p => p.BBookingDetails)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__B_Booking__Fligh__086B34A6");
        });

        modelBuilder.Entity<BCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__B_Custom__A4AE64B85D6017CD");

            entity.ToTable("B_Customers");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerEmailId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerUsername)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BFlight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__B_Flight__8A9E148EF4EF09DD");

            entity.ToTable("B_Flights");

            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.Destination)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FlightName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Origin)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("pk_B_Locations");

            entity.ToTable("B_Locations");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Locations)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Badmin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__BAdmin__719FE4889DBF7D98");

            entity.ToTable("BAdmin");

            entity.Property(e => e.AdminName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
