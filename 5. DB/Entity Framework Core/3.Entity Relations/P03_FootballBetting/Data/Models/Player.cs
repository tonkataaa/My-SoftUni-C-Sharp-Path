using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
	public class Player
	{
        public Player()
        {
			this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
		public int PlayerId { get; set; }

		[Required]
		[MaxLength(250)]
		public string Name { get; set; }

		[Required]
		public int SquadNumber { get; set; }

		public int TeamId { get; set; }
		
		public Town Town { get; set; }

		public int PositionId { get; set; }
		public Position Position { get; set; }

		public bool IsInjured { get; set; }

		public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
	}
}
