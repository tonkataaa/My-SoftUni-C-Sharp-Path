using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
	public class Position
	{
        public Position()
        {
			this.Players = new HashSet<Player>();
        }

        [Key]
		public int PositionId { get; set; }

		[Required]
		[MaxLength(250)]
		public string Name { get; set; }

		public ICollection<Player> Players { get; set; }
	}
}
