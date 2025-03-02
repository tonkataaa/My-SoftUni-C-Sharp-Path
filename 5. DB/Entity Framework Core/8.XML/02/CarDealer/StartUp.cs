using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.Models;
using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static Azure.Core.HttpHeader;

namespace CarDealer
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			var context = new CarDealerContext();


			//09.
			//var xmlFileRead = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\Datasets\suppliers.xml");
			//Console.WriteLine(ImportSuppliers(context, xmlFileRead));

			//10.
			//var xmlFileRead = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\Datasets\parts.xml");
			//Console.WriteLine(ImportSuppliers(context, xmlFileRead));

			//11.
			//var xmlFileRead = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\Datasets\cars.xml");
			//Console.WriteLine(ImportCars(context, xmlFileRead));

			//12.
			//var xmlFileRead = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\Datasets\customers.xml");
			//Console.WriteLine(ImportCustomers(context, xmlFileRead));

			//13.
			//var xmlFileRead = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\Datasets\sales.xml");
			//Console.WriteLine(ImportSales(context, xmlFileRead));

			//14.
			//Console.WriteLine(GetCarsWithDistance(context));

			//15.
			//Console.WriteLine(GetCarsFromMakeBmw(context));

			//16.
			//Console.WriteLine(GetLocalSuppliers(context));

			//17.
			//Console.WriteLine(GetCarsWithTheirListOfParts(context));

			////18.
			//Console.WriteLine(GetTotalSalesByCustomer(context));

			//19.
			Console.WriteLine(GetSalesWithAppliedDiscount(context));
		}

		//09.
		public static string ImportSuppliers(CarDealerContext context, string inputXml)
		{
			var serializer = new XmlSerializer(typeof(SupplierInputModel[]),
				new XmlRootAttribute("Suppliers"));

			var textRead = new StringReader(inputXml);
			var suppliersDto = serializer.Deserialize(textRead) as SupplierInputModel[];

			var suppliers = suppliersDto.Select(s => new Supplier
			{
				Name = s.Name,
				IsImporter = s.IsImporter
			})
			.ToList();

			context.Suppliers.AddRange(suppliers);
			context.SaveChanges();

			return $"Successfully imported {suppliers.Count}";
		}

		//10.
		public static string ImportParts(CarDealerContext context, string inputXml)
		{
			var serializer = new XmlSerializer(typeof(PartInputModel[]),
				new XmlRootAttribute("Parts"));

			using (var textRead = new StringReader(inputXml))
			{
				var partsDto = serializer.Deserialize(textRead) as PartInputModel[];

				var parts = partsDto
					.Select(p => new Part
					{
						Name = p.Name,
						Price = p.Price,
						Quantity = p.Quantity,
						SupplierId = p.SupplierId
					})
					.ToList();

				context.Parts.AddRange(parts);
				context.SaveChanges();

				return $"Successfully imported {parts.Count}";
			}
		}

		//11.
		public static string ImportCars(CarDealerContext context, string inputXml)
		{
			var xmlSerializer = new XmlSerializer(typeof(List<CarInputModel>),
				new XmlRootAttribute("Cars"));

			List<CarInputModel> carInputModels;
			using (var reader = new StringReader(inputXml))
			{
				carInputModels = (List<CarInputModel>)xmlSerializer.Deserialize(reader);
			}

			var validPartIds = context.Parts.Select(p => p.Id).ToList();

			var cars = new List<Car>();
			foreach (var carInput in carInputModels)
			{
				var car = new Car
				{
					Make = carInput.Make,
					Model = carInput.Model,
					TravelledDistance = carInput.TravelDistance
				};

				var uniquePartIds = carInput.Parts
					.Select(p => p.Id)
					.Distinct()
					.Where(id => validPartIds.Contains(id))
					.ToList();

				foreach (var partId in uniquePartIds)
				{
					car.PartCars.Add(new PartCar
					{
						PartId = partId
					});
				}
				cars.Add(car);
			}

			context.Cars.AddRange(cars);
			context.SaveChanges();

			return $"Successfully imported {cars.Count}.";
		}

		//12.
		public static string ImportCustomers(CarDealerContext context, string inputXml)
		{
			var xmlSerializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));
			var reader = new StringReader(inputXml);

			var customersDto = xmlSerializer.Deserialize(reader) as CustomerInputModel[];
			var customers = customersDto.Select(s => new Customer
			{
				Name = s.Name,
				BirthDate = s.BirthDate,
				IsYoungDriver = s.IsYoungDriver,
			})
			.ToList();

			context.Customers.AddRange(customers);
			context.SaveChanges();

			return $"Successfully imported {customers.Count}";
		}

		//13.
		public static string ImportSales(CarDealerContext context, string inputXml)
		{
			var xmlSerializer = new XmlSerializer(typeof(SalesInputModel[]), new XmlRootAttribute("Sales"));
			var reader = new StringReader(inputXml);

			var validCarIds = context.Cars.Select(c => c.Id).ToList(); //FK
			var validCustomerIds = context.Customers.Select(c => c.Id).ToList(); //FK

			var salesDto = xmlSerializer.Deserialize(reader) as SalesInputModel[];
			var sales = salesDto
			.Where(s => validCarIds.Contains(s.CarId) && validCustomerIds.Contains(s.CustomerId)) //FK
			.Select(s => new Sale
			{
				CarId = s.CarId,
				CustomerId = s.CustomerId,
				Discount = s.Discount
			})
			.ToList();

			context.Sales.AddRange(sales);
			context.SaveChanges();

			return $"Successfully imported {sales.Count}";
		}

		//14.
		public static string GetCarsWithDistance(CarDealerContext context)
		{
			var cars = context.Cars
				.Where(c => c.TravelledDistance > 2_000_000)
				.OrderBy(c => c.Make)
				.ThenBy(c => c.Model)
				.Take(10)
				.Select(c => new
				{
					c.Make,
					c.Model,
					c.TravelledDistance
				})
				.ToList();

			var xml = new XElement("cars",
				   cars.Select(c =>
				   new XElement("car",
				   new XElement("make", c.Make),
				   new XElement("model", c.Model),
				   new XElement("travelled-distance", c.TravelledDistance))));

			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\DTO\Output\";
			string filePath = Path.Combine(directoryPath, "cars.xml");
			xml.Save(filePath);

			return "Exported successfully";
		}

		//15.
		public static string GetCarsFromMakeBmw(CarDealerContext context)
		{
			var cars = context.Cars
				.Where(c => c.Make == "BMW")
				.OrderBy(c => c.Model)
				.ThenByDescending(c => c.TravelledDistance)
				.Select(c => new
				{
					c.Id,
					c.Model,
					c.TravelledDistance
				})
				.ToList();

			var xml = new XElement("cars", 
				cars.Select(c => 
				new XElement("car",
				new XAttribute("id", c.Id),
				new XAttribute("model", c.Model),
				new XAttribute("travelled-distance", c.TravelledDistance))));

			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\DTO\Output\";
			string filePath = Path.Combine(directoryPath, "bmw-cars.xml");
			xml.Save(filePath);

			return "Exported successfully";
		}

		//16.
		public static string GetLocalSuppliers(CarDealerContext context)
		{
			var suppliers = context.Suppliers
				.Where(s => !s.IsImporter)
				.Select(s => new
				{
					s.Id,
					s.Name,
					PartsCount = s.Parts.Count
				})
				.ToList();

			var xml = new XElement("suppliers",
				suppliers.Select(s =>
				new XElement("supplier",
				new XAttribute("id", s.Id),
				new XAttribute("name", s.Name),
				new XAttribute("parts-count", s.PartsCount))));

			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\DTO\Output\";
			string filePath = Path.Combine(directoryPath, "local-suppliers.xml");
			xml.Save(filePath);

			return "Exported successfully";
		}

		//17.
		public static string GetCarsWithTheirListOfParts(CarDealerContext context)
		{
			var cars = context.Cars
				.OrderByDescending(c => c.TravelledDistance)
				.ThenBy(c => c.Model)
				.Take(5)
				.Select(c => new
				{
					c.Make,
					c.Model,
					c.TravelledDistance,
					Parts = c.PartCars.Select(s => new
					{
						s.Part.Name,
						s.Part.Price
					})
					.OrderByDescending(s => s.Price)
					.ToList()
				})
				.ToList();

			var xml = new XElement("cars",
				cars.Select(c =>
					new XElement("car",
							new XAttribute("make", c.Make),
							new XAttribute("model", c.Model),
							new XAttribute("travelled-distance", c.TravelledDistance),
					new XElement("parts",
							c.Parts.Select(p =>
								new XElement("part",
									new XAttribute("name", p.Name),
									new XAttribute("price", p.Price)))))));

			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\DTO\Output\";
			string filePath = Path.Combine(directoryPath, "cars-and-parts.xml");
			xml.Save(filePath);

			return "Exported successfully";
		}

		//18.
		public static string GetTotalSalesByCustomer(CarDealerContext context)
		{
			var customers = context.Customers
				.Where(c => c.Sales.Any())
				.Select(c => new
				{
					c.Name,
					BoughtCars = c.Sales.Count,
					TotalSpentMoney = c.Sales.Sum(c => c.Car.PartCars.Sum(pc => pc.Part.Price))
				})
				.OrderBy(c => c.TotalSpentMoney)
				.ToList();

			var xml = new XElement("customers",
				customers.Select(c =>
				new XElement("customer",
				new XAttribute("full-name", c.Name),
				new XAttribute("bought-cars", c.BoughtCars),
				new XAttribute("spent-money", c.TotalSpentMoney))));

			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\DTO\Output\";
			string filePath = Path.Combine(directoryPath, "customers-total-sales.xml");
			xml.Save(filePath);

			return "Exported successfully";

		}

		//19.
		public static string GetSalesWithAppliedDiscount(CarDealerContext context)
		{
			var sales = context.Sales
				.Select(s => new 
				{
					
					Make = s.Car.Make,
					Model = s.Car.Model,
					TravelledDistance = s.Car.TravelledDistance,
					Discount = s.Discount,
					CustomerName = s.Customer.Name,
					Price = s.Car.PartCars.Sum(pc => pc.Part.Price), 
					PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100) 
				})
				.ToList();

			var xml = new XElement("sales",
				sales.Select(s =>
					new XElement("sale",
						new XElement("car",
							new XAttribute("make", s.Make),
							new XAttribute("model", s.Model),
							new XAttribute("travelled-distance", s.TravelledDistance)
						),
						new XElement("discount", s.Discount),
						new XElement("customer-name", s.CustomerName),
						new XElement("price", s.Price.ToString("F2")),
						new XElement("price-with-discount", s.PriceWithDiscount.ToString("F2")))));

			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\01\CarDealer\DTO\Output\";
			string filePath = Path.Combine(directoryPath, "sales-discounts.xml");
			xml.Save(filePath);
			return "Exported successfully";
		}
	}
}