using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project1.Models;

public partial class Phase2EndProjectContext : DbContext
{
    public Phase2EndProjectContext()
    {
    }

    public Phase2EndProjectContext(DbContextOptions<Phase2EndProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-QHQ6E5M;database=Phase2_end_Project;trusted_connection=true;TrustserverCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptCode).HasName("PK__Departme__BB9B9551489CCF8B");

            entity.ToTable("Department");

            entity.Property(e => e.DeptCode).ValueGeneratedNever();
            entity.Property(e => e.DeptName).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpCode).HasName("PK__Employee__7DA847CBBACB5929");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpCode).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DepartmentCode).HasColumnName("Department_Code");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmpName).HasMaxLength(50);

            entity.HasOne(d => d.DepartmentCodeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentCode)
                .HasConstraintName("FK__Employee__Depart__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
