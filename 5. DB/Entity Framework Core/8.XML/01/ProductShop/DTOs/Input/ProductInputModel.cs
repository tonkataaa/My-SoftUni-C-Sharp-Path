﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductShop.DTOs.Input
{
	[XmlType("Product")]
	public class ProductInputModel
	{
		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("price")]
		public decimal Price { get; set; }

		[XmlElement("sellerId")]
		public int SellerId { get; set; }

		[XmlElement("buyerId")]
		public int BuyerId { get; set; }

	}
}
