using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
	public class Bet
	{
		[Key]
		public int BetId { get; set; }

		[Required]
		public decimal Amount { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(200)")]
		public string Prediction { get; set; }

		public DateTime DateTime { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		public int GameId { get; set; }
		public Game Game { get; set; }
	}
}
