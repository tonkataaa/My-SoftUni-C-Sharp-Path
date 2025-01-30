using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace ADO.NET
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Server = .\\SQLEXPRESS; Integrated Security = true; Database = MinionsDB";
			Console.Write("Enter villain ID: ");
			int villainId = int.Parse(Console.ReadLine());

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @villainId", connection);
				command.Parameters.AddWithValue("@villainId", villainId);
				var villainName = command.ExecuteScalar();

				if (villainName == null ) 
				{
					Console.WriteLine("No such villain was found.");
					return;
				}

				var deleteMinions = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @villainId", connection);
				deleteMinions.Parameters.AddWithValue("@villainId", villainId);
				int minionsReleased = deleteMinions.ExecuteNonQuery();

				var deleteVillain = new SqlCommand("DELETE FROM Villains WHERE Id = @villainId", connection);
				deleteVillain.Parameters.AddWithValue("@villainId", villainId);
				deleteVillain.ExecuteNonQuery();

				Console.WriteLine($"{villainName} was deleted.");
				Console.WriteLine($"{minionsReleased} minions were released.");
			}
		}
	}
}
