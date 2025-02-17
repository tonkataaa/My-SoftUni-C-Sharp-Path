﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
	public class Homework
	{
		[Key]
		public int HomeworkId { get; set; }

		[Column(TypeName = "varchar(2048)")]
		public string Content { get; set; }

		public ContentType ContentType { get; set; }

		public DateTime SubmissionTime { get; set; }

		public int StudentId { get; set; }
		public Student Student { get; set; }

		public int CourseId { get; set; }
		public Course Course { get; set; }




	}
}
