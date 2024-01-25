using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace firstMVCPoject.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BhaveshSbaccount> BhaveshSbaccounts { get; set; }

    public virtual DbSet<BhaveshSbtransaction> BhaveshSbtransactions { get; set; }

    public virtual DbSet<BhaveshUser> BhaveshUsers { get; set; }

    public virtual DbSet<CustomerBk> CustomerBks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BhaveshSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__Bhavesh___BE2ACD6ED88BC83B");

            entity.ToTable("Bhavesh_SBAccount");

            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BhaveshSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Bhavesh___55433A6BB815F1BA");

            entity.ToTable("Bhavesh_SBTransaction");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.BhaveshSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__Bhavesh_S__Accou__7EF6D905");
        });

        modelBuilder.Entity<BhaveshUser>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK__Bhavesh___7ED91ACF367D9F3E");

            entity.ToTable("Bhavesh_Users");

            entity.Property(e => e.EmailId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerBk>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Customer__C1FFD861DEA9A643");

            entity.ToTable("Customer_Bk");

            entity.Property(e => e.Cemail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Cname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phn)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
