using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
	[XmlType("Car")]
	public class CarInputModel
	{

		[XmlElement("make")]
		public string Make { get; set; }

		[XmlElement("model")]
		public string Model { get; set; }

		[XmlElement("TraveledDistance")]
		public long TravelDistance { get; set; }

		[XmlArray("parts")]
		[XmlArrayItem("partId")]
		public List<PartId> Parts { get; set; } = new List<PartId>();

	}


	public class PartId
	{
		[XmlAttribute("id")]
		public int Id { get; set; }
	}
}

 //< Car >
	//< parts >

	//  < partId id = "38" />

	//  < partId id = "102" />

	//  < partId id = "23" />

	//  < partId id = "116" />

	//  < partId id = "46" />

	//  < partId id = "68" />

	//  < partId id = "88" />

	//  < partId id = "104" />

	//  < partId id = "71" />

	//  < partId id = "32" />

	//  < partId id = "114" />

	//</ parts >
 // </ Car >