using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
	public class Color
	{
        public Color()
        {
			this.PrimaryKitTeams = new HashSet<Team>();
			this.SecondaryKitTeams = new HashSet<Team>();
        }

        [Key]
        public int ColorId { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		public ICollection<Team> PrimaryKitTeams { get; set; }

		public ICollection<Team> SecondaryKitTeams {  get; set; }

    }
}
