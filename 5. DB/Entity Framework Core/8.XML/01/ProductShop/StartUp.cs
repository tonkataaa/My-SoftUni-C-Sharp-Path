using Castle.DynamicProxy;
using ProductShop.Data;
using ProductShop.DTOs.Input;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //01.
            //var inputXml = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\02\ProductShop\Datasets\users.xml");
            //Console.WriteLine(ImportUsers(context, inputXml));

            //02.
            //var inputXml = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\02\ProductShop\Datasets\products.xml");
            //Console.WriteLine(ImportProducts(context, inputXml));

            //03.
            //var inputXml = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\02\ProductShop\Datasets\categories.xml");
            //Console.WriteLine(ImportCategories(context, inputXml));

            //04.
            //        var inputXml = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\02\ProductShop\Datasets\categories-products.xml");
            //Console.WriteLine(ImportProducts(context, inputXml));

            //05.
            //Console.WriteLine(GetProductsInRange(context));

            //06.
            //Console.WriteLine(GetSoldProducts(context));

            //07.
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //08.
            Console.WriteLine(GetUsersWithProducts(context));
		}

		//01.
		public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(UserInputModel[]), 
                new XmlRootAttribute("Users"));

            var textRead = new StringReader(inputXml);
            var usersDto = serializer.Deserialize(textRead) as UserInputModel[];

            var users = usersDto.Select(u => new User
            {
                FirstName = u.FirstName, 
                LastName = u.LastName,
                Age = u.Age
            })
            .ToList();

            context.Users.AddRange(users);
			context.SaveChanges();

            return $"Successfully imported {users.Count}";
		}

        //02.
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductInputModel[]),
                new XmlRootAttribute("Products"));
            using var textRead = new StringReader(inputXml);

			var users = context.Users.Select(u => u.Id).ToHashSet();
			var productsDto = xmlSerializer.Deserialize(textRead) as ProductInputModel[];
            
            var products = productsDto
			.Where(p => users.Contains(p.SellerId) && (p.BuyerId == null || users.Contains(p.BuyerId)))
			.Select(p => new Product
            {
                Name = p.Name,
                Price = p.Price,
                SellerId = p.SellerId,
                BuyerId = p.BuyerId
            })
            .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
		}

        //03.
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));
            var textRead = new StringReader(inputXml);
            var categoryDto = xmlSerializer.Deserialize(textRead) as CategoryInputModel[];

            var categories = categoryDto.Select(u => new Category
            {
                Name = u.Name,
            })
            .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
		}

		//04.
		public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
		{
			var xmlSerializer = new XmlSerializer(typeof(CategoryProductsInputModel[]), new XmlRootAttribute("CategoryProducts"));
			using var textRead = new StringReader(inputXml);

			var categoryProductsDto = (CategoryProductsInputModel[])xmlSerializer.Deserialize(textRead);

			var categories = context.Categories.Select(c => c.Id).ToHashSet();
			var products = context.Products.Select(p => p.Id).ToHashSet();

			var categoryProducts = categoryProductsDto
				.Where(cp => categories.Contains(cp.CategoryId) && products.Contains(cp.ProductId))
				.Select(cp => new CategoryProduct { CategoryId = cp.CategoryId, ProductId = cp.ProductId })
				.ToList();

			context.CategoryProducts.AddRange(categoryProducts);
			context.SaveChanges();

			return $"Successfully imported {categoryProducts.Count}";
		}

		//05.
		public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    BuyerName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToList();

            var xml = new XElement("Products",
                products.Select(p => new XElement("Product",
                new XElement("name", p.Name),
                new XElement("price", p.Price),
                new XElement("buyer", p.BuyerName))
                ));
			var xmlDoc = new XDocument(xml);

			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\02\ProductShop\DTOs\Output\";
			string filePath = Path.Combine(directoryPath, "products-in-range.xml");
			xmlDoc.Save(filePath);

            return "Exported successfully";
        }

		//06.
		public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Products
                .Where(u => u.Buyer.ProductsSold.Count > 0)
                .OrderBy(u => u.Buyer.LastName)
                .ThenBy(u => u.Buyer.FirstName)
                .Take(5)
                .Select(u => new
                {
                    FirstName = u.Buyer.FirstName,
                    LastName = u.Buyer.LastName,
                    Products = u.CategoryProducts.Select(p => new
                    {
                        p.Product.Name,
                        p.Product.Price
                    })
                })
                .ToList();

			var xml = new XElement("Users",
	            users.Select(u => new XElement("User",
		                        new XElement("firstName", u.FirstName),
		                        new XElement("lastName", u.LastName),
		                        new XElement("products",
			    u.Products.Select(p => new XElement("Product",
				                new XElement("name", p.Name),
				                new XElement("price", p.Price)
			                                                   ))
		                                                      )
	                                                        ))
                                                           );


			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\02\ProductShop\DTOs\Output\";
			string filePath = Path.Combine(directoryPath, "user-sold-products.xml");
			xml.Save(filePath);

			return "Exported successfully";
		}

		//07.
		public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    NumberOfProducts = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderBy(p => p.NumberOfProducts)
                .ToList();

            var xml = new XElement("Categories",
                categories.Select(c =>
                new XElement("Category",
                new XElement("name", c.Name),
                new XElement("count", c.NumberOfProducts),
                new XElement("averagePrice", c.AveragePrice),
                new XElement("totalRevenue", c.TotalRevenue))));


			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\02\ProductShop\DTOs\Output\";
			string filePath = Path.Combine(directoryPath, "categories-by-products.xml");
			xml.Save(filePath);

			return "Exported successfully";
		}

        //08.
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold.Count,
                    Products = u.ProductsSold.Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                })
                .ToList();

            var xml = new XElement("Users",
                users.Select(c =>
                new XElement("User",
                new XElement("firstName", c.FirstName),
                new XElement("lastName", c.LastName),
                new XElement("age", c.Age),
                new XElement("SoldProducts",
                new XElement("count", c.SoldProducts),
                new XElement("products",
                new XElement("Product",
                new XElement("name", c.Products.Select(p => p.Name)),
                new XElement("price", c.Products.Select(p => p.Price))))))));

			string directoryPath = @"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\9.XML\02\ProductShop\DTOs\Output\";
			string filePath = Path.Combine(directoryPath, "users-and-products.xml");
			xml.Save(filePath);

			return "Exported successfully";
		}
    }
}