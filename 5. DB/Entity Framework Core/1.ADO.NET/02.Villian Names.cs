using System.Data.SqlClient;

namespace ADO.NET
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Server = .\\SQLEXPRESS; Integrated Security = true; Database = MinionsDB";
			string query = @"
                SELECT v.Name, COUNT(mv.MinionId) AS MinionsCount
                FROM Villains AS v
                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                GROUP BY v.Id, v.Name
                HAVING COUNT(mv.MinionId) > 3
                ORDER BY COUNT(mv.MinionId) DESC";
	
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (var command = new SqlCommand(query, connection))
				{
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							string villainName = reader["Name"].ToString();
							int minionsCount = (int)reader["MinionsCount"];
							Console.WriteLine($"{villainName} - {minionsCount}");
						}
					}
				}
			}

		}

		private static void ExecuteCommand(string query, SqlConnection connection)
		{
			var command = new SqlCommand(query, connection);
			command.ExecuteNonQuery();
		}
	}
}
