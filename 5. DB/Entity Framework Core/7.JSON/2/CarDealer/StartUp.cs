using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
			var context = new CarDealerContext();

			//08.
			//string jsonFile = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\suppliers.json");
			//string result = ImportSuppliers(context, jsonFile);
			//Console.WriteLine(result);

			//09.
			//string jsonFile = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\parts.json");
			//string result = ImportParts(context, jsonFile);
			//Console.WriteLine(result);

			//10.
			//string jsonFile = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\cars.json");
			//string result = ImportCars(context, jsonFile);
			//Console.WriteLine(result);

			//11.
			//string jsonFile = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\customers.json");
			//string result = ImportCustomers(context, jsonFile);
			//Console.WriteLine(result);

			//12.
			//string jsonFile = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\sales.json");
			//string result = ImportSales(context, jsonFile);
			//Console.WriteLine(result);

			//13.
			//string result = GetOrderedCustomers(context);
			//Console.WriteLine(result);

			//14.
			//string result = GetLocalSuppliers(context);
			//Console.WriteLine(result);

			//15.
			//string result = GetCarsWithTheirListOfParts(context);
			//Console.WriteLine(result);

			//16.
			//string result = GetTotalSalesByCustomer(context);
			//Console.WriteLine(result);

			//17.
			string result = GetSalesWithAppliedDiscount(context);
			Console.WriteLine(result);
		}

		//08.
		public static string ImportSuppliers(CarDealerContext context, string inputJson)
		{
			var supplier = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
			context.Suppliers.AddRange(supplier);

			context.SaveChanges();

			return $"Successfully imported {supplier.Count}.";
		}

		//09.
		public static string ImportParts(CarDealerContext context, string inputJson)
		{
			var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);
			foreach (var link in parts)
			{
				var supplier = context.Suppliers.Find(link.SupplierId);
				if (supplier != null)
				{
					context.Parts.Add(link);
				}
			}

			context.SaveChanges();
			return $"Successfully imported {parts.Count}.";
		}

		//10.
		public static string ImportCars(CarDealerContext context, string inputJson)
		{
			var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);
			foreach (var link in cars)
			{
				foreach (var partCar in link.PartCars)
				{
					var part = context.Parts.Find(partCar.PartId);
					if (part != null)
					{
						link.PartCars.Add(new PartCar { Car = link, Part = part });
					}
				}

				context.Cars.Add(link);
			}
			context.SaveChanges();

			return $"Successfully imported {cars.Count}.";
		}

		//11.
		public static string ImportCustomers(CarDealerContext context, string inputJson)
		{
			var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
			context.Customers.AddRange(customers);
			context.SaveChanges();

			return $"Successfully imported {customers.Count}.";
		}

		//12.
		public static string ImportSales(CarDealerContext context, string inputJson)
		{
			var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

			foreach (var sale in sales)
			{
				var car = context.Cars.Find(sale.CarId);
				var customer = context.Customers.Find(sale.CustomerId);

				if (car != null && customer != null)
				{
					context.Sales.Add(sale);
				}
			}
			context.SaveChanges();

			return $"Successfully imported {sales.Count}.";
		}

		//13.
		public static string GetOrderedCustomers(CarDealerContext context)
		{
			var customers = context.Customers
				.OrderBy(c => c.BirthDate)
				.ThenBy(c => c.IsYoungDriver ? 1 : 0)
				.Select(c => new
				{
					Name = c.Name,
					BirthDate = c.BirthDate,
					IsYoungDriver = c.IsYoungDriver
				})
				.ToList();

			var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
			File.WriteAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\ordered-customers.json", json);

			return $"Successfully exported {customers.Count} products to JSON.";
		}

		//14.
		public static string GetLocalSuppliers(CarDealerContext context)
		{
			var suppliers = context.Suppliers
				.Where(p => p.Parts.Any(s => !s.Supplier.IsImporter))
				.Select(s => new
				{
					Id = s.Id,
					Name = s.Name,
					PartsCount = s.Parts.Count
				})
				.ToList();

			var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
			File.WriteAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\local-suppliers.json", json);

			return $"Successfully exported {suppliers.Count} products to JSON.";
		}

		//15.
		public static string GetCarsWithTheirListOfParts(CarDealerContext context)
		{
			var cars = context.Cars
				.Select(c => new
				{
					Make = c.Make,
					Model = c.Model,
					TravelledDistance = c.TravelledDistance,
					Parts = c.PartCars.Select(p => new
					{
						Name = p.Part.Name,
						Price = p.Part.Price.ToString("F2")
					})
				})
				.ToList();

			var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
			File.WriteAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\cars-with-parts.json", json);

			return $"Successfully exported {cars.Count} products to JSON.";
		}

		//16.
		public static string GetTotalSalesByCustomer(CarDealerContext context)
		{
			var customers = context.Customers
				.Where(c => c.Sales.Any())
				.Select(c => new
				{
					Name = c.Name,
					BoughtCars = c.Sales.Count(),
					TotalSpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
				})
				.OrderByDescending(m => m.TotalSpentMoney)
				.ThenByDescending(bc => bc.BoughtCars)
				.ToList();

			var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
			File.WriteAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\total-sales.json", json);

			return $"Successfully exported {customers.Count} products to JSON.";
		}

		//17.
		public static string GetSalesWithAppliedDiscount(CarDealerContext context)
		{
			var sales = context.Sales
				.Select(s => new
				{
					Car = new
					{
						Make = s.Car.Make,
						Model = s.Car.Model,
						TravelledDistance = s.Car.TravelledDistance,
					},
					customerName = s.Customer.Name,
					Discount = s.Discount,
					price = s.Car.PartCars.Sum(pc => pc.Part.Price),
					priceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100m) 
				})
				.Take(10)
				.ToList();

			var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
			File.WriteAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\2\CarDealer\Datasets\sales-with-applies.json", json);

			return $"Successfully exported {sales.Count} products to JSON.";
		}
	}
}