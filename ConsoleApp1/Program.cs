using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = "hellow world";

            string startingPoints = "            ";

            byte[] asciiBytes = Encoding.ASCII.GetBytes(startingPoints);

            for (int c = 0; c < destination.Length; c++)//see what I did there
            {
                while ((char)asciiBytes[c] != destination[c])
                {
                    asciiBytes[c]++;
                    Console.WriteLine(Encoding.ASCII.GetString(asciiBytes, 0, asciiBytes.Length));
                }

            }

        }
    }
}
