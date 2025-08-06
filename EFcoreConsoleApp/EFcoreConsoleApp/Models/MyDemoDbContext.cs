using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFcoreConsoleApp.Models;

public partial class MyDemoDbContext : DbContext
{
    public MyDemoDbContext()
    {
    }

    public MyDemoDbContext(DbContextOptions<MyDemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MenuList> MenuLists { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Parlour> Parlours { get; set; }

    public virtual DbSet<ParlourList> ParlourLists { get; set; }

    public virtual DbSet<ParlourService> ParlourServices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Service1> Services1 { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public object MenuList { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DAISH\\MSSQLSERVER01;database=MyDemoDB;integrated security=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuList>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__MenuList__4CA0FADC15046C96");

            entity.ToTable("MenuList");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.DishName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dish_name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__46596229946A2FBA");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Parlour>(entity =>
        {
            entity.HasKey(e => e.ParlourId).HasName("PK__Parlour__848804C0581D10B0");

            entity.ToTable("Parlour");

            entity.Property(e => e.ParlourId).HasColumnName("parlour_id");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.ParlourName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("parlour_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Rating).HasColumnName("rating");
        });

        modelBuilder.Entity<ParlourList>(entity =>
        {
            entity.HasKey(e => e.ParlourId).HasName("PK__ParlourL__848804C0FEF31852");

            entity.ToTable("ParlourList");

            entity.Property(e => e.ParlourId).HasColumnName("parlour_id");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.ParlourName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("parlour_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Rating).HasColumnName("rating");
        });

        modelBuilder.Entity<ParlourService>(entity =>
        {
            entity.HasKey(e => new { e.ParlourId, e.ServiceId }).HasName("PK__ParlourS__6768DF4ADCE59A47");

            entity.Property(e => e.ParlourId).HasColumnName("parlour_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Parlour).WithMany(p => p.ParlourServices)
                .HasForeignKey(d => d.ParlourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParlourSe__parlo__797309D9");

            entity.HasOne(d => d.Service).WithMany(p => p.ParlourServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParlourSe__servi__7A672E12");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProdId).HasName("PK__Product__C55AC32BE1F7040A");

            entity.ToTable("Product");

            entity.Property(e => e.ProdId)
                .ValueGeneratedNever()
                .HasColumnName("Prod_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Pro_name");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestId).HasName("PK__Restaura__9A2078C0CF8D0163");

            entity.ToTable("Restaurant");

            entity.Property(e => e.RestId).HasColumnName("rest_id");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phno");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__3E0DB8AF2254670A");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<Service1>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__3E0DB8AFF4729EC1");

            entity.ToTable("Services");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Img)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CF762323A");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
