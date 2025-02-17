using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
	public class User
	{
        public User()
        {
			this.Bets = new HashSet<Bet>();    
        }

        [Key]
		public int UserId { get; set; }

		[Required]
		[MaxLength(200)]
		public string Username { get; set; }


		[Required]
		[MaxLength(200)]
		public string Password { get; set; }

		[Required]
		[MaxLength(320)]
		public string Email { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		[Required]
		public decimal Balance { get; set; }

		public ICollection<Bet> Bets { get; set; }

	}
}
