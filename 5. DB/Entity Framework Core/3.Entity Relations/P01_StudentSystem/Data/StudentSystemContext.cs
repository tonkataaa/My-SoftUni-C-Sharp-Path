﻿using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
	public class StudentSystemContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Homework> HomeworkSubmissions { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }


		public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
	   : base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<StudentCourse>()
				.HasKey(sc => new { sc.StudentId, sc.CourseId });

			modelBuilder.Entity<StudentCourse>()
				.HasOne(sc => sc.Student)
				.WithMany(s => s.CourseEnrollments)
				.HasForeignKey(sc => sc.StudentId);

			modelBuilder.Entity<StudentCourse>()
				.HasOne(sc => sc.Course)
				.WithMany(c => c.StudentsEnrolled)
				.HasForeignKey(sc => sc.CourseId);
		}
	}
}
