using System;
using Codecool.LifeOfAnts.Ants;
using Codecool.LifeOfAnts.Colony;
using Codecool.LifeOfAnts.Img;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            View.PrintFile("Title.txt");
            View.PrintFile("Ant.txt");

            Console.WriteLine("Provide colony width: \n");
            var area = GetInput();
            AntColony colony = new AntColony(area);
            colony.CreateEmptyColony();

            Console.WriteLine("Provide number of workers: \n");
            var workers = GetInput();

            Console.WriteLine("Provide number of soldiers: \n");
            var soldiers = GetInput();

            Console.WriteLine("Provide number of drones: \n");
            var drones = GetInput();
            Console.Clear();

            colony.GenerateAnts(workers, soldiers, drones);
            Console.WriteLine("Hello Ants!");
            Console.WriteLine("Press Enter to update the colony\n");
            colony.PrintColony();
            Console.WriteLine("Colony statistics: \n");
            Console.WriteLine("All ants: " + (workers + drones + soldiers + 1));
            Console.WriteLine("Workers * : " + workers + "\n" + "Soldiers @ : " + soldiers + "\n" + "Drones # : " + drones + "\n" + "The Queen & " + "\n");
            Console.WriteLine("Colony area: " + area + "x" + area);

            while (IsUpdated())
            {
                Console.Clear();
                Console.WriteLine("Mating status: \n");
                colony.UpdateAndPrintColony();
                Console.WriteLine("Colony statistics: \n");
                Console.WriteLine("All ants: " + (workers + drones + soldiers + 1));
                Console.WriteLine("Workers * : " + workers + "\n" + "Soldiers @ : " + soldiers + "\n" + "Drones # : " + drones + "\n" + "The Queen & " + "\n");
                Console.WriteLine("Colony area: " + area + "x" + area + "\n");
                Console.WriteLine("Press Enter to Update the colony \nPress 'q' to finish the simulation\n");
            }
        }

        /// <summary>
        ///     Checks user input if go next
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsUpdated()
        {
            var userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else if (userInput.KeyChar == 'q')
            {
                return false;
            }

            return IsUpdated();
        }

        /// <summary>
        ///  Asks user for input
        /// </summary>
        /// <returns>int</returns>
        public static int GetInput()
        {
            var input = Console.ReadLine();
            while (!CheckIfInt(input))
            {
                Console.WriteLine("Must be a number: \n");
                input = Console.ReadLine();
            }

            return Int32.Parse(input);
        }

        //    Console.WriteLine("Provide number of workers: \n");
        //    var workers = Console.ReadLine();
        //    while (CheckIfInt(workers))
        //    {
        //        Console.WriteLine("Must be a number: \n");
        //        workers = Console.ReadLine();
        //    }

        //    Console.WriteLine("Provide number of soldiers: \n");
        //    var soldiers = Console.ReadLine();
        //    while (CheckIfInt(soldiers))
        //    {
        //        Console.WriteLine("Must be a number: \n");
        //        soldiers = Console.ReadLine();
        //    }

        //    Console.WriteLine("Provide number of drones: \n");
        //    var drones = Console.ReadLine();
        //    while (CheckIfInt(drones))
        //    {
        //        Console.WriteLine("Must be a number: \n");
        //        drones = Console.ReadLine();
        //    }
        //}

        /// <summary>
        ///  Asks user for input
        /// </summary>
        /// <param name="input">Input of the user</param>
        /// <returns>bool</returns>
        public static bool CheckIfInt(string input)
        {
            if (Int32.TryParse(input, out _))
            {
                return true;
            }

            return false;
        }
    }
}
