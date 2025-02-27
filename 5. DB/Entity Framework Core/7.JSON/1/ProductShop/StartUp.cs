using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Protocols.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

			//01.
			//string userJson = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\1\ProductShop\Datasets\users.json");

			//02.
			//string userJson = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\1\ProductShop\Datasets\products.json");

			//03.
			//string categoriesJson = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\1\ProductShop\Datasets\categories.json");
			//string result = ImportCategories(context, categoriesJson);

			//04.
			//string categoryProductsJson = File.ReadAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\1\ProductShop\Datasets\categories-products.json");
			//string result = ImportCategoryProducts(context, categoryProductsJson);
			//Console.WriteLine(result);

			//05.
			//string result = GetProductsInRange(context);
			//Console.WriteLine(result);

            //06.
            //string result = GetSoldProducts(context);
            //Console.WriteLine(result);

            //07.
            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);

		}


        //01.
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //02.
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {

            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //03.
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //04.
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProductsJson = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            foreach (var link in categoryProductsJson)
            {
                var category = context.Categories.Find(link.CategoryId);
                var product = context.Products.Find(link.ProductId);

                if (category != null && product != null)
                {
                    context.CategoryProducts.Add(link);
                }
            }
            context.SaveChanges();
            return $"Successfully imported {categoryProductsJson.Count}";
        }

        //05.
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                }
                )
                .OrderBy(p => p.Price)
                .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string json = JsonConvert.SerializeObject(products, settings);
			File.WriteAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\1\ProductShop\Datasets\productsExport.json", json);

            return $"Successfully exported {products.Count} products to JSON.";
		}

		//06.
		public static string GetSoldProducts(ProductShopContext context)
        {
            var user = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var json = JsonConvert.SerializeObject(user, settings);
			File.WriteAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\1\ProductShop\Datasets\sold-products.json", json);

            return $"Successfully exported {user.Count} products to JSON.";
        }

        //07.
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var user = context.Users
                .Where(p => p.ProductsSold.Any(p => p.Buyer != null) && p.ProductsSold.Count > 1)
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        ProductName = p.Name,
                        Price = p.Price
                    })
                    .Where(p => p.ProductName != null && p.Price != null)
                    .ToList()
                });

			var settings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				ContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new CamelCaseNamingStrategy()
				}
			};

            var json = JsonConvert.SerializeObject(user, settings);

            File.WriteAllText(@"D:\IT\SoftUni\SoftUni C#\05.DB\Еntity Framework Core\8.JSON\1\ProductShop\Datasets\user-with-products.json", json);

            return $"Successfully exported {user.Count()} user with products to JSON.";
		}
    }
}