using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftUni;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni.Data;

public partial class SoftUniContext : DbContext
{
	public SoftUniContext()
	{
	}

	public SoftUniContext(DbContextOptions<SoftUniContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Address> Addresses { get; set; }
	public virtual DbSet<Department> Departments { get; set; }
	public virtual DbSet<Employee> Employees { get; set; }
	public virtual DbSet<Project> Projects { get; set; }
	public virtual DbSet<Town> Towns { get; set; }
	public virtual DbSet<EmployeesProject> EmployeesProjects { get; set; }  

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning Move connection string to configuration
		=> optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SoftUni;Trusted_Connection=True;Encrypt=False;");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressText)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TownId).HasColumnName("TownID");

            entity.HasOne(d => d.Town).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.TownId)
                .HasConstraintName("FK_Addresses_Towns");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_Employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HireDate).HasColumnType("smalldatetime");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(15, 4)");

            entity.HasOne(d => d.Address).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Employees_Addresses");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Employees_Employees");

            entity.HasMany(d => d.Projects).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesProject",
                    r => r.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeesProjects_Projects"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeesProjects_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "ProjectId");
                        j.ToTable("EmployeesProjects");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
                        j.IndexerProperty<int>("ProjectId").HasColumnName("ProjectID");
                    });
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.Property(e => e.TownId).HasColumnName("TownID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });


		modelBuilder.Entity<EmployeesProject>()
			.HasKey(ep => new { ep.EmployeeId, ep.ProjectId }); // Composite Key

		modelBuilder.Entity<EmployeesProject>()
			.HasOne(ep => ep.Employee)
			.WithMany(e => e.EmployeesProjects)
			.HasForeignKey(ep => ep.EmployeeId)
			.OnDelete(DeleteBehavior.ClientSetNull);

		modelBuilder.Entity<EmployeesProject>()
			.HasOne(ep => ep.Project)
			.WithMany(p => p.EmployeesProjects)
			.HasForeignKey(ep => ep.ProjectId)
			.OnDelete(DeleteBehavior.ClientSetNull);

		modelBuilder.Entity<EmployeesProject>().ToTable("EmployeesProjects");
		OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
