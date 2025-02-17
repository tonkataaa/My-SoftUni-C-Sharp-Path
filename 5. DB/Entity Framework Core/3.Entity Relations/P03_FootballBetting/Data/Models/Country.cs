using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
	public class Country
	{
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        [Key]
        public int CountryId { get; set; }

		[Required]
		[MaxLength(250)]
		public string Name { get; set; }

		public ICollection<Town> Towns { get; set; }
    }
}
