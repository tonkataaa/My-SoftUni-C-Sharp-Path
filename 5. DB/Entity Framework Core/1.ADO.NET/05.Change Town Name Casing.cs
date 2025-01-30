using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO.NET
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Server = .\\SQLEXPRESS; Integrated Security = true; Database = MinionsDB";

			string countryName = Console.ReadLine();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string countryQuery = @"
										SELECT t.Name 
										FROM Towns AS t
										JOIN Countries AS c ON c.Id = t.CountryCode
										WHERE c.Name = @countryName;
										";


				string updateQuery = @"
                    UPDATE Towns
                    SET Name = UPPER(Name)
                    WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName);
                ";


				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					command.Parameters.AddWithValue("@countryName", countryName);
					int affectedRows = command.ExecuteNonQuery();

					if (affectedRows == 0) 
					{
						Console.WriteLine("No town names were affected.");
						return;
					}

					Console.WriteLine($"{affectedRows} town names were affected. ");
				}

				using (var command = new SqlCommand(countryQuery, connection))
				{
					command.Parameters.AddWithValue("countryName", countryName);
					var reader = command.ExecuteReader();

					var updatedTowns = new List<string>();
					while (reader.Read()) 
					{
						updatedTowns.Add(reader["Name"].ToString());
					}
					Console.WriteLine(string.Join(", ", updatedTowns));
				}
			}

		}
	}
}
