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

    public virtual DbSet<AdminUsers> AdminUsers { get; set; }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Restaurants> Restaurants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminUsers>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__admin_us__B9BE370FED07CE43");

            entity.ToTable("admin_users");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.UserPass).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__category__DD5DDDBD2C88C3E2");

            entity.ToTable("category");

            entity.Property(e => e.CatId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("cat_id");
            entity.Property(e => e.Cname)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuItems>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__menu_ite__52020FDD4FAFCB1D");

            entity.ToTable("menu_items");

            entity.Property(e => e.ItemId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("item_id");
            entity.Property(e => e.CatId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("cat_id");
            entity.Property(e => e.Idescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Iname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Cat).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__menu_item__cat_i__3D5E1FD2");
        });

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

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FED383DCE");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.UserPass).HasMaxLength(50);
            entity.Property(e => e.UserAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}

