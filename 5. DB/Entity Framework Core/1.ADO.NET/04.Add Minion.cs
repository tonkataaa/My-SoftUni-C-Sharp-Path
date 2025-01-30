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

			string[] minionInfo = Console.ReadLine()
				.Split(" ");
			string[] villainInfo = Console.ReadLine()
				.Split(" ");


			string minionName = minionInfo[1];
			int minionAge = int.Parse(minionInfo[2]);
			string minionTown = minionInfo[3];
			string villianName = villainInfo[1];

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string townQuery = "SELECT Id FROM Towns WHERE Name = @townName";

				var townCommand = new SqlCommand(townQuery, connection);
				townCommand.Parameters.AddWithValue("@townName", minionTown);
				var townId = townCommand.ExecuteScalar();

				if (townId == null)
				{
					string insertTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";
					var insertTownCommand = new SqlCommand(insertTownQuery, connection);
					insertTownCommand.Parameters.AddWithValue("@townName", minionTown);

					townId = insertTownCommand.ExecuteScalar();
					Console.WriteLine($"Town {minionTown} was addded to the database.");
				}
				
				string villainNameQuery = "SELECT Id FROM Villains WHERE Name = @Name";
				var villainCommand = new SqlCommand(villainNameQuery, connection);
				villainCommand.Parameters.AddWithValue("@Name", villianName);
				var villainId = villainCommand.ExecuteScalar();

				if (villainId == null)
				{
					string insertVillainQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
					var insertVillainCommand = new SqlCommand(insertVillainQuery, connection);
					insertVillainCommand.Parameters.AddWithValue("@villainName", villianName);

					villainId = insertVillainCommand.ExecuteScalar();
					Console.WriteLine($"Villain {villianName} was added to the database.");
				}

				string minionNameQuery = "SELECT Id FROM Minions WHERE Name = @Name";

				var minionCommand = new SqlCommand(minionNameQuery, connection);
				minionCommand.Parameters.AddWithValue("@Name", minionName);
				var minionId = minionCommand.ExecuteScalar();

				if (minionId == null)
				{
					string insertMinionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";
					var insertMinionCommand = new SqlCommand(insertMinionQuery, connection);
					insertMinionCommand.Parameters.AddWithValue("@nam", minionName);
					insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
					insertMinionCommand.Parameters.AddWithValue("@townId", townId);

					string insertMinionVillainQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
					var insertMinionVillainCommand = new SqlCommand(insertMinionVillainQuery , connection);
					insertMinionVillainCommand.Parameters.AddWithValue("@minionId", minionId);
					insertMinionVillainCommand.Parameters.AddWithValue("@villainId", villainId);
					insertMinionVillainCommand.ExecuteNonQuery();

					Console.WriteLine($"Successfully added {minionName} to be minion of {villainInfo[1]}.");
				}
			}

		}
	}
}
