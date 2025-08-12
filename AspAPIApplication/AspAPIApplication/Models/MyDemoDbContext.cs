using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspAPIApplication.Models;

public partial class MyDemoDbContext : DbContext
{
    public MyDemoDbContext()
    {
    }

    public MyDemoDbContext(DbContextOptions<MyDemoDbContext> options)
        : base(options)
    {
    }

 
    public virtual DbSet<Item> Items { get; set; }

 
    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DAISH\\MSSQLSERVER01;initial catalog=MyDemoDB;integrated security=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("items");
        });

      
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudId);

            entity.ToTable("students");

            entity.HasIndex(e => e.ItemId, "IX_students_ItemId");

            entity.Property(e => e.StudId).HasColumnName("studId");
            entity.Property(e => e.Dept).HasColumnName("dept");
            entity.Property(e => e.StudName).HasColumnName("studName");

            entity.HasOne(d => d.Item).WithMany(p => p.Students)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
