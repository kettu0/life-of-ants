using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Codecool.LifeOfAnts.Img
{
    /// <summary>
    /// Static class for View
    /// </summary>
    public class View
    {
        /// <summary>
        /// Static method for image printing
        /// </summary>
        /// <param name="fileName"> String with the filename</param>
        public static void PrintFile(string fileName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            IEnumerable<string> fileContent;

            var filesFolderName = Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location).Parent.Parent.Parent + "\\Img\\";
            fileContent = File.ReadLines(filesFolderName + fileName);
            string gameTitle = string.Empty;

            foreach (string line in fileContent)
            {
                Console.WriteLine(gameTitle + line);
            }

            Console.ResetColor();
        }
    }
}
