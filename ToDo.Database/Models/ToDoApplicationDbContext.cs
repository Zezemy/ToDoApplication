﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoApplication.Database.Models;

public partial class ToDoApplicationDbContext : DbContext
{
    public ToDoApplicationDbContext()
    {
    }

    public ToDoApplicationDbContext(DbContextOptions<ToDoApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDo> ToDos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6QFEOEL;Initial Catalog=ToDoApp;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ToDo__3214EC077F14DFEF");

            entity.ToTable("ToDo");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(4000);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(4000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}