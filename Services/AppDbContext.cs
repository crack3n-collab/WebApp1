/*
using System;
using System.Collections.Generic;
using FYP2.Model;
using Microsoft.EntityFrameworkCore;

namespace FYP2.Services { 

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Restaurants> Restaurants { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__46596229608089FB");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ItemId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("item_id");
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Item).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__orders__item_id__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__orders__user_id__403A8C7D");
        });

        modelBuilder.Entity<Restaurants>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__restaura__3B0FAA91A24F1994");

            entity.ToTable("restaurants");

            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");
            entity.Property(e => e.Raddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Rname)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

       
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}
*/