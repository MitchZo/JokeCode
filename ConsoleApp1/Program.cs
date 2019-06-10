using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

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

        public static void BreakDieRoller(){
            for(int i = 0; i < 1000000; i++){
                Console.WriteLine($"Attempt:{i}");
                DiceRoll();
            }

            Console.WriteLine("You fool.  DiceRoller is unbreakable");
        }

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
            
            //report back the results of the types of dies rolled
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

        public static void BadMagician(){
            Console.WriteLine("Welcome to the Hairy Porters den of dark magicals.  I am Hairy Porter and I will use youre name alone to guess your phone number.");
            var dontNeedThis = Console.ReadLine();


            Console.WriteLine($"OOOOOOooooOOOOOhhh, {dontNeedThis}, what an interesting name.  Using this information, and only this information, I will guess your phone number");

            List<string> fuckYous = new List<string>()
            {
                $"Wow {dontNeedThis}, arent you just a big fucking man, coming in here, and making me look like the asshole",
                $"I bet you think you are so funny.",
                $"You were adopted, and Im glad it wasnt by me",
                $"Think again {dontNeedThis}, think again, because I learned this trick in prison",
                $"*Weeps openly* *sighs* *collapses*",
                $"Dont you fucking lie to me {dontNeedThis}.  Ive seen 'How To Train your dragon' 1-3 and I will nightfury you're so hard",
            };

            List<string> sincereAppologies = new List<string>()
            {
                $"*deep breaths* alright alright, im sorry, its been a long week . {dontNeedThis}, please give me another shot",
                $"Okay, that was a fluke.  Im a god dammed professional.  GATHER ROUND YOU FOOLS.  IM ABOUT TO BLOW THIS TINY MANS MIND",
                $"*Slaps his own face* Okay, sorry, im low on magic juice.  Stand by *Pops flask*",
                $"I will give you $700 to tweet that I got this right on the first try",
                $"Here is your new sim card.  Abra Kadabra"
            };

            string phoneNumberGuess = GuessPhoneNumber();

            Console.WriteLine($"Is this your phone number? - {phoneNumberGuess}");

            var response = Console.ReadLine();

            Random random = new Random();

            while(!response.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {

                Console.WriteLine(fuckYous[random.Next(0, fuckYous.Count - 1)]);

                int pregnantPausesCount = random.Next(3, 10);

                for(int i = 0; i <= pregnantPausesCount; i++){
                    Thread.Sleep(1000);
                    Console.WriteLine("...");
                }

                
                Console.WriteLine(sincereAppologies[random.Next(0, sincereAppologies.Count - 1)]);

                phoneNumberGuess = GuessPhoneNumber();

                Console.WriteLine($"Is this your phone number? - {phoneNumberGuess}");

                response = Console.ReadLine();
            }
        }

        private static string GuessPhoneNumber()
        {

            Random random = new Random();

            int areaCode = random.Next(0, 999);
            int demOtherThree = random.Next(0, 999);
            int thoseFouryBois = random.Next(0, 9999);

            return $"{String.Format("{0:D3}", areaCode)}-{String.Format("{0:D3}", demOtherThree)}-{String.Format("{0:D4}", thoseFouryBois)}";
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
