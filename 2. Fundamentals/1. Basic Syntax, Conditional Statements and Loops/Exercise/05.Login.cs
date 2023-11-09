using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 1st Input:
Acer
login
go
let me in
recA

2nd Input:
momo
omom

 */
namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = new string(username.ToCharArray().Reverse().ToArray());
            int attempts = 4;

            while (attempts > 0)
            {
                attempts -= 1;
                string inputPass = Console.ReadLine();
                if (inputPass == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    if (attempts == 0)
                    {
                        Console.WriteLine($"User {username} blocked!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }

                }
            }


        }
    }
}
