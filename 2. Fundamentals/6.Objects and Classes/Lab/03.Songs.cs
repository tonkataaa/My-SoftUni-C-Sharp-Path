using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _03._Songs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Input
			int numberOfSongs = int.Parse(Console.ReadLine());

			//Solution
			List<Song> songs = new List<Song>();
			for (int i = 0; i < numberOfSongs; i++)
			{
				string[] commandArgs = Console.ReadLine()
					.Split('_');

				string typeList = commandArgs[0];
				string name = commandArgs[1];
				string time = commandArgs[2];

				Song song = new Song(typeList, name, time);
				songs.Add(song);
			}

			string songType = Console.ReadLine();

			//Output
			for (int i = 0; i < songs.Count; i++)
			{
				Song currentSong = songs[i];

				if (songType == "all")
				{
					Console.WriteLine(currentSong.Name);
				}
				else if (songType == currentSong.TypeList)
				{
					Console.WriteLine(currentSong.Name);
				}
			}
		}
	}

	internal class Song
	{
		public Song(string typeList, string name, string time)
		{
			TypeList = typeList;
			Name = name;
			Time = time;
		}
		public string TypeList { get; set; }

		public string Name { get; set; }

		public string Time { get; set; }
	}
}