using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace P03_FootballBetting.Data.Models
{
	public class Team
	{
        public Team()
        {
			this.HomeGames = new HashSet<Game>();
			this.AwayGames = new HashSet<Game>();
			this.Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "varchar(2500)")]
		public string LogoUrl { get; set; }

		[Required]
		[Column(TypeName = "char(3)")]
		public string Initials { get; set; }

		public decimal Budget { get; set; }

		public int PrimaryKitColorId { get; set; }
		public Color PrimaryKitColor { get; set; }
		public int SecondaryKitColorId { get; set; }
		public Color SecondaryKitColor { get; set; }

		public int TownId { get; set; }

		public Town Town { get; set; }

		[InverseProperty("HomeTeam")]
		public ICollection<Game> HomeGames { get; set; }
		[InverseProperty("AwayTeak")]
		public ICollection<Game> AwayGames { get; set; }

		public ICollection<Player> Players { get; set; }
	}
}
