// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612.

namespace ExpressionTreeConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// HW 5 console app to demonstrate expresison tree functionality.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The logic for the console app.
        /// </summary>
        /// <param name="args">
        /// If we ran this on the command line.
        /// </param>
        public static void Main(string[] args)
        {
            int response = 0;
            string expression = string.Empty;
            string value = string.Empty;
            string name= string.Empty;
            double result = 0.0;
            while (response != 4)
            {
                Console.WriteLine("\nMenu (current expression: " + expression + ")");
                Console.WriteLine("\n\t 1 = Enter a new expression");
                Console.WriteLine("\n\t 2 = Set a variable value");
                Console.WriteLine("\n\t 3 = Evaluate tree");
                Console.WriteLine("\n\t 4 = Quit");
                response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        Console.WriteLine("Enter Expression: ");
                        expression = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter variable name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter variable value: ");
                        value = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Expression evaluated to: ");
                        Console.WriteLine(result);
                        break;
                    case 4:
                        Console.WriteLine("Done!");
                        break;
                }
            }
        }
    }
}
