using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dont look at me
            JokieBoi jokieBoi = new JokieBoi();
            MethodInfo[] jokieBoisMethods = typeof(JokieBoi).GetMethods(BindingFlags.Static| BindingFlags.DeclaredOnly| BindingFlags.Public);        

            //nothing to see here
            GenerateMenu(jokieBoisMethods);
            
            int selection = -1;

            ///Keep going
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

            //A little further
        }

        //Not there yet
        static void GenerateMenu(MethodInfo[] jokieBoisMethods)
        {
            for(int i = 1; i <= jokieBoisMethods.Length; i++)
            {
                Console.WriteLine($"{i}){jokieBoisMethods[i-1].Name}");
            }

            Console.WriteLine($"{jokieBoisMethods.Length + 1})Quit");
        }
    }

    //Nailed it
    //Any functions that you add to this JokieBoi will be included in the stupid little menu that the console prints out.
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

        public static void RandomNameGenerator(){
            Console.WriteLine("How long would you like the name to be?");
            var nameLength = Console.ReadLine();

            byte[] asciiBytes = new byte[nameLength.Length];

            for(int i = 0; i < asciiBytes.Length; i++)
            {
                Random rng = new Random();
                int newChar = rng.Next(33, 126);
                
                asciiBytes[i] = (byte)newChar;
            }

            Console.WriteLine("Greetings lord " + Encoding.ASCII.GetString(asciiBytes, 0, asciiBytes.Length));
        }

        public static void DiceRoll(){
            Console.WriteLine("");
            Console.WriteLine("--------------");
            Console.WriteLine("");
            Console.WriteLine("Rolling Di(c)e...");
            
            Random rng = new Random();
            
            int result = 0;
            int numberOfDice = rng.Next(1, 100);            
            Dictionary<int, int> numberOfSidesToInstances = new Dictionary<int, int>();

            for(int i = 0; i < numberOfDice; i++)
            {                
                //determine how many sides are on this die
                int numSides = rng.Next(2, 50);

                if(numberOfSidesToInstances.ContainsKey(numSides))
                {
                    //increment the count of this kind of die
                    numberOfSidesToInstances[numSides]++;
                }
                else
                {
                    numberOfSidesToInstances.Add(numSides, 1);
                }

                                             //outer bound is excluded, so this should be 21 if die is 20-sided
                int actualRoll = rng.Next(1, numSides + 1);
                result += actualRoll;
            }

            Console.WriteLine($"You rolled {numberOfDice} randomly determined dice.");
            Console.WriteLine($"Now of those dice...");

            foreach(int numberOfSides in numberOfSidesToInstances.Keys.OrderBy(x => x))
            {
                int instances = numberOfSidesToInstances[numberOfSides];
                string verb = "was";
                if(instances > 1){
                    verb = "were";
                }

                Console.WriteLine($"{instances} {verb} {numberOfSides}-sided.");
            }

            Console.WriteLine($"The result was: {result}!");
            Console.WriteLine("");
            Console.WriteLine("--------------");
            Console.WriteLine("");
        }

        public static void EnterBirthdate(){
            Console.WriteLine("What is your birthdate?");
            string birthdate = Console.ReadLine();

            string enteredBirthdate = string.Join("\r\n", birthdate.ToCharArray());
            
            Console.WriteLine("Here is your entered birthdate");
            Console.Write(enteredBirthdate);

        }
    }
}
