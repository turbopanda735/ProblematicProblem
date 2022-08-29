using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main()
        {
            var validUserResponse = false;
            while (!validUserResponse)
            {
                Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
                var userResponse = Console.ReadLine();
                if (userResponse.ToLower() == "no")
                {
                    Console.WriteLine("bye!");
                    return;
                }
                else if (userResponse.ToLower() == "yes")
                    validUserResponse = true;
                else validUserResponse = false;
            }

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            var userName = Console.ReadLine();

            Console.WriteLine();
            var userAge = GetAge();

            Console.WriteLine();
            var seeList = false;
            var validSeeListTwo = false;
            while (!validSeeListTwo)
            {
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                var validSeeList = Console.ReadLine();
                if (validSeeList.ToLower() == "sure")
                {
                    validSeeListTwo = true;
                    seeList = true;
                }
                else if (validSeeList.ToLower() == "no thanks")
                {
                    validSeeListTwo = true;
                }
                else validSeeListTwo = false;
            }

            Console.WriteLine();
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            var validAddToList = false;
            var addToList = false;
            while (!validAddToList)
            {
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                var userAddToList = Console.ReadLine();
                if (userAddToList.ToLower() == "yes")
                {
                    validAddToList = true;
                    addToList = true;
                }
                else if (userAddToList.ToLower() == "no")
                {
                    validAddToList = true;
                }
                else validAddToList = false;
            }

            Console.WriteLine();
            while (addToList)
            {
                Console.Write("What would you like to add? ");
                var userAddition = Console.ReadLine();
                activities.Add(userAddition);
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no. invalid input will ask you again: ");
                var moreInput = Console.ReadLine();
                if (moreInput.ToLower() == "yes")
                    addToList = true;
                else if (moreInput.ToLower() == "no")
                    addToList = false;
            }

            Console.WriteLine();
            bool validAnswer = false;
            while (!validAnswer)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                var randomActivity = GetRandomActivity(userAge);

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                var userAnswer = Console.ReadLine();
                if (userAnswer.ToLower() == "redo")
                    validAnswer = false;
                else validAnswer = true;
            }
        }
        public static int GetAge()
        {
            int userAge;
            Console.Write("What is your age? ");
            var tempUserAge = Console.ReadLine();
            while (!int.TryParse(tempUserAge, out userAge))
            {
                Console.Write("What is your age? ");
                tempUserAge = Console.ReadLine();
            }
            return userAge;
        }

        public static string GetRandomActivity(int userAge)
        {
            var tooYoung = true;
            int randomNumber;
            string randomActivity;
            do
            {
                randomNumber = rng.Next(activities.Count);
                randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Picking something else!");
                    Console.WriteLine();
                    activities.Remove(randomActivity);
                }
                else tooYoung = false;
            } while (tooYoung);
            return randomActivity;
        }
    }
}