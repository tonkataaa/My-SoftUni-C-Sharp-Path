using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Data
{
	public class DatabaseInitializer
	{
		public static void Initialize(ProductShopContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
