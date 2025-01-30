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
			int[] minionsIds = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var updateQuery = @"UPDATE Minions 
                                   SET Name = UPPER(LEFT(Name, 1)) + LOWER(SUBSTRING(Name, 2, LEN(Name))), 
                                       Age += 1 
                                   WHERE Id = @Id";

				using (var updateCommand = new SqlCommand(updateQuery, connection))
				{
					updateCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int);

					foreach (var minionId in minionsIds)
					{
						updateCommand.Parameters["@Id"].Value = minionId;
						updateCommand.ExecuteNonQuery();
					}
				}

				var selectMinionsQuery = "SELECT Name, Age FROM Minions";
				using (var selectCommand = new SqlCommand(selectMinionsQuery, connection))
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