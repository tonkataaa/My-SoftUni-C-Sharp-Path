﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
	public class Student
	{
		public Student()
		{
			this.HomeworkSubmissions = new HashSet<Homework>();
			this.CourseEnrollments = new HashSet<StudentCourse>();
		}

		[Key]
		public int StudentId { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Column(TypeName = "varchar(10)")]
		public string PhoneNumber { get; set; }

		public DateTime RegisteredOn { get; set; }

		public DateTime? Birthday { get; set; }

		public ICollection<Homework> HomeworkSubmissions { get; set; }
		public ICollection<StudentCourse> CourseEnrollments { get; set; }
	}
}
