using System.Data.SqlClient;

namespace ADO.NET
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Server = .\\SQLEXPRESS; Integrated Security = true; Database = MinionsDB";
			Console.Write("Enter villian ID: ");
			int villainId = int.Parse(Console.ReadLine());

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				var command = new SqlCommand("SELECT * FROM Villains AS v WHERE v.Id = @villainId", connection);
				command.Parameters.AddWithValue("@villainId", villainId);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Console.WriteLine($"Villain: {reader["Name"]}");
						reader.Close();

						var selectCommand = new SqlCommand(@  "SELECT m.Name, m.Age " +
															  "FROM Villains AS v " +
															  "INNER JOIN MinionsVillains AS mv " +
															  "ON mv.VillainId = v.Id " +
															  "INNER JOIN Minions AS m " +
															  "ON m.Id = mv.MinionId " +
															  "WHERE v.Id = @villainId " +
															  "ORDER BY m.Name ", connection);

						selectCommand.Parameters.AddWithValue("@villainId", villainId);
						SqlDataReader minionReader = selectCommand.ExecuteReader();

						if (minionReader.HasRows)
						{
							int index = 1;
							while (minionReader.Read())
							{
								Console.WriteLine($"{index}. {minionReader["Name"]} {minionReader["Age"]}");
								index++;
							}

						}
						else
						{
							Console.WriteLine("(no minions)");
						}

					}
				}
				else
				{
					Console.WriteLine($"No villain with ID {villainId} exists in the database.");
				}

			}

		}
	}
}
