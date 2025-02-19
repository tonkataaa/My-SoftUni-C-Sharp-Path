namespace BookShop
{
	using BookShop.Models.Enums;
	using Data;
    using Initializer;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using Z.EntityFramework.Plus;

	public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //2.
            //Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));

            //3.
            //Console.WriteLine(GetGoldenBooks(db));

            //4.
            //Console.WriteLine(GetBooksByPrice(db));

            //5.
            //Console.WriteLine(GetBooksNotReleasedIn(db, 1998));

            //6.
            //Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));

            //7.
            //Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));

            //8.
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));

            //9.
            //Console.WriteLine(GetBookTitlesContaining(db, "WOR"));

            //10.
            //Console.WriteLine(GetBooksByAuthor(db, "R"));

            //11.
            //Console.WriteLine(CountBooks(db, 40));

            //12.
            //Console.WriteLine(CountCopiesByAuthor(db));

            //13.
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //14.
            //Console.WriteLine(GetMostRecentBooks(db));

            //15.
            //IncreasePrices(db);

            //16.
            Console.WriteLine(RemoveBooks(db));
		}

		//2.
		public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriciton = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                 .Where(b => b.AgeRestriction == ageRestriciton)
                 .Select(b => b.Title)
                 .OrderBy(title => title)
                 .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString();
        }

        //3.
        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books
                .Where(t => t.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in titles)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString();
        }

        //4.
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString();
        }

        //5.
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {


            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString();
        }

        //6.
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var inputParams = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var bookTitles = context.Books
                .Where(b => b.BookCategories.Any(b => inputParams.Contains(b.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in bookTitles)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString();
           
        }

        //7.
		public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateParse = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateParse)
                .OrderByDescending(d => d.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            var sb = new StringBuilder();
            foreach ( var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return sb.ToString();
        }

		//8.
		public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString();
        }

		//9.
		public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }

		//10.
		public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.StartsWith(input))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString();
        }

		//11.
		public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)               
                .ToList();

            return books.Count();
        }

		//12.
		public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesCounter = context.Authors           
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.TotalCopies)
                .ToList();

            var sb = new StringBuilder();
            foreach ( var book in copiesCounter)
            {
                sb.AppendLine($"{book.FullName} - {book.TotalCopies}");
            }

            return sb.ToString();
        }

		//13.
		public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfit = context.Books
                .Join(context.BooksCategories,
                b => b.BookId,
                c => c.BookId,
                (b, c) => new {b, c})
                .Join(context.Categories,
                ct => ct.c.CategoryId,
                cat => cat.CategoryId,
                (ct, cat) => new
                {
                    CategoryName = cat.Name,
                    TotalProfit = ct.b.Price * ct.b.Copies

                })
                .OrderBy(c => c.CategoryName)
                .ThenByDescending(b => b.TotalProfit)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in totalProfit)
            {
                sb.AppendLine($"{book.CategoryName} ${book.TotalProfit}");
            }

            return sb.ToString();
        }

		//14.
		public static string GetMostRecentBooks(BookShopContext context)
        {
			var booksCategory = context.Categories
                .Select(cat => new
                {
                    CategoryName = cat.Name,
                    Books = cat.CategoryBooks
                    .Select(cb => cb.Book)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .Select(b => new {b.Title, Year = b.ReleaseDate.Value.Year})
                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var category in booksCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                     sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString();
		}

		//15.
		public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

		//16.
		public static int RemoveBooks(BookShopContext context)
        {
             var booksForDeleting = context.Books
                    .Where(b => b.Copies < 4200)
                    .Delete();

            return booksForDeleting;
        }
	}
}
