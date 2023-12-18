using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _6._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //Input
           List<int> firstPlayer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse) 
                .ToList();

            List<int> secondPlayer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            //Solution
            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                int firstPlayerCard = firstPlayer[0];
                int secondPlayerCard = secondPlayer[0];

                if (firstPlayerCard > secondPlayerCard)  //adding to first player hand
                {
                    firstPlayer.Add(firstPlayerCard);
                    firstPlayer.Add(secondPlayerCard);
                }
                else if (firstPlayerCard < secondPlayerCard) //adding to second player hand
                {
                    secondPlayer.Add(secondPlayerCard);
                    secondPlayer.Add(firstPlayerCard);
                }

                firstPlayer.RemoveAt(0);
                secondPlayer.RemoveAt(0);
            }


            //Output
            if (firstPlayer.Count > 0 )
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else if (secondPlayer.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
        }
    }
}