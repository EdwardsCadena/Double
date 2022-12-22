using System;
using System.Collections.Generic;
using Double.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Double.Infrastructure.Data;

public partial class DoublepContext : DbContext
{
    public DoublepContext()
    {
    }

    public DoublepContext(DbContextOptions<DoublepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<TypeIdenti> TypeIdentis { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Identifier).HasName("PK__Persons__821FB0188985BAD8");

            entity.Property(e => e.DateCreation).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumberIdentification)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

        });

        modelBuilder.Entity<TypeIdenti>(entity =>
        {
            entity.HasKey(e => e.IdTypeIdenti).HasName("PK__TypeIden__A88E8E4DF7FA4CCC");

            entity.ToTable("TypeIdenti");

            entity.Property(e => e.Description)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Identifier).HasName("PK__Users__821FB018B65C5598");

            entity.Property(e => e.DateCreation).HasColumnType("date");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

    }

}
