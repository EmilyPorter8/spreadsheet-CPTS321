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
            string valueInput = string.Empty;
            double value = 0.0;
            string name = string.Empty;
            double result = 0.0;
            SpreadsheetEngine.ExpressionTree tree = null;

            while (response != 4) // go through loop until user gives 4.
            {
                Console.WriteLine("\nMenu (current expression: " + expression + ")");
                Console.WriteLine("\n\t 1 = Enter a new expression");
                Console.WriteLine("\n\t 2 = Set a variable value");
                Console.WriteLine("\n\t 3 = Evaluate tree");
                Console.WriteLine("\n\t 4 = Quit");
                if (int.TryParse(Console.ReadLine(), out response))
                {
                    // try to switch above line to tryparse instead, that way we can have some kidn of exception handeling.
                    switch (response)
                    {
                        case 1:
                            Console.WriteLine("Enter Expression: ");
                            expression = Console.ReadLine();
                            tree = new SpreadsheetEngine.ExpressionTree(expression);
                            break;
                        case 2:
                            Console.WriteLine("Enter variable name: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter variable value: ");
                            valueInput = Console.ReadLine();
                            value = double.Parse(valueInput);
                            tree.SetVariable(name, value);
                            break;
                        case 3:
                            Console.WriteLine("Expression evaluated to: ");
                            result = tree.Evaluate();
                            Console.WriteLine(result);
                            break;
                        case 4:
                            Console.WriteLine("Done!");
                            break;
                    }
                }
                else
                {
                }
            }
        }
    }
}
