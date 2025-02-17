using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
	public class PlayerStatistic
	{
		public int GameId { get; set; }

		public Game Game {  get; set; }

		public int PlayerId { get; set; }

		public Player Player { get; set; }

		[Required]
		public int ScoredGoals { get; set; }

		[Required]
		public int Assists { get; set; }

		[Required]
		public decimal MinutesPlayed { get; set; }
	}
}
