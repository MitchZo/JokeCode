using System;
using System.Reflection;
using System.Text;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            JokieBoi jokieBoi = new JokieBoi();
            MethodInfo[] jokieBoisMethods = typeof(JokieBoi).GetMethods(BindingFlags.Static| BindingFlags.DeclaredOnly| BindingFlags.Public);        


            GenerateMenu(jokieBoisMethods);
            
            int selection = -1;

          
            while(selection != jokieBoisMethods.Length + 1){
                Console.WriteLine("Select Your Jokie Boi:");
                string rawinput = Console.ReadLine().Trim();
                int parsedInput = -1;

                if(int.TryParse(rawinput, out parsedInput)){
                    if((parsedInput - 1) < jokieBoisMethods.Length){
                        jokieBoisMethods[parsedInput - 1].Invoke(jokieBoi, null);
                        GenerateMenu(jokieBoisMethods);
                    }
                    selection = parsedInput;
                }
            }

        }

        static void GenerateMenu(MethodInfo[] jokieBoisMethods)
        {
            for(int i = 1; i <= jokieBoisMethods.Length; i++)
            {
                Console.WriteLine($"{i}){jokieBoisMethods[i-1].Name}");
            }

            Console.WriteLine($"{jokieBoisMethods.Length + 1})Quit");
        }
    }

    public class JokieBoi
    {
        public static void SuperHelloWorld()
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
