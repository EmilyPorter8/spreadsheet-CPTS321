//Emily Porter
//011741612
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("BST IMPLEMENTATION");
            Console.WriteLine();
            Console.WriteLine("\nPlease enter list of integers in the range[0,100], seperated by spaces:"); 
            string userList = Console.ReadLine(); //grab input string from user

            BST userBST = new BST(userList); //create BST with string input

            userBST.Print(); //print out tree from least to greatest
            Console.WriteLine();
            Console.WriteLine();

            userBST.Statistics(); //print statistics of tree
            Console.WriteLine();

            Console.WriteLine("Please enter a key");
            Console.ReadKey();
        }
    }
}
