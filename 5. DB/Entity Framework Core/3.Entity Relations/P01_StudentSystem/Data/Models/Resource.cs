﻿using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
	public class Resource
	{
		[Key]
		public int ResourceId {  get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "varchar(2500)")]
		public string Url { get; set; }

		public ResourceType ResourceType { get; set; }

		public int CourseId { get; set; }

		public Course Course { get; set;}
	}
}
