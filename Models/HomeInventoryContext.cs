using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManagerApi.Models;

public partial class HomeInventoryContext : DbContext
{
    public HomeInventoryContext()
    {
    }

    public HomeInventoryContext(DbContextOptions<HomeInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Saving> Savings { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3306;Database=homeInventory;Uid=test-inventory;Pwd=112233");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("items");

            entity.HasIndex(e => e.CategoryId, "FK_ITEM_CATEGORY");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("'uuid()'")
                .HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_ITEM_CATEGORY");
        });

        modelBuilder.Entity<Saving>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("savings");

            entity.HasIndex(e => e.TagId, "FK_SAVING_TAG");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("'uuid()'")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Currency)
                .HasMaxLength(45)
                .HasColumnName("currency");
            entity.Property(e => e.Goal).HasColumnName("goal");
            entity.Property(e => e.Icon)
                .HasMaxLength(45)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.TagId).HasColumnName("tagId");

            entity.HasOne(d => d.Tag).WithMany(p => p.Savings)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("FK_SAVING_TAG");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tags", tb => tb.HasComment("nomenclature that hold all possible categories for every item in the household"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("'uuid()'")
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .HasColumnName("color");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
