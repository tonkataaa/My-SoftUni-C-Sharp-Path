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
			List<object> minions = new List<object>();
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				var selectQuery = "SELECT Name FROM Minions";
				var select = new SqlCommand(selectQuery, connection);
				var reader = select.ExecuteReader();

				while (reader.Read())
				{
					minions.Add(reader["Name"]);
				}

			}
			List<object> listedMinions = new List<object>()
				{
					minions[0],
					minions[10],
					minions[1],
					minions[9],
					minions[2],
					minions[8],
					minions[3],
					minions[7],
					minions[4],
					minions[6],
					minions[5],
				};

			foreach (var minion in listedMinions)
			{
				Console.WriteLine(minion);
			}
		}
	}
}
