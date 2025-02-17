﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
	public class Town
	{
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }

        [Key]
        public int TownId { get; set; }

		[Required]
		[MaxLength(250)]
		public string Name { get; set; }

		public int CountryId { get; set; }

		public Country Country { get; set; }

		public ICollection<Team> Teams { get; set; }
    }
}
