using System;
using System.Data.SqlClient;
using System.Linq;

namespace ADO.NET
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Server = .\\SQLEXPRESS; Integrated Security = true; Database = MinionsDB";
			int minionId = int.Parse(Console.ReadLine());

			using (var connection = new SqlConnection(connectionString)) 
			{
				connection.Open();

				string sqlQuery = "usp_GetOlder";

				using (var command = new SqlCommand(sqlQuery, connection))
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@id", minionId);
					command.ExecuteNonQuery();
				}

				var selectQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";
				using (var selectCommand = new SqlCommand(selectQuery, connection))
				{
					selectCommand.Parameters.AddWithValue(selectQuery, minionId);

					using (var reader = selectCommand.ExecuteReader())
					{
						while (reader.Read())
						{
							Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
						}
					}
				}
			}
		}
	}
}