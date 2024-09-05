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
            Console.WriteLine("\nPlease enter list of integers:");
            //string userList = Console.ReadLine();
            string testlist = "0 28 3 3 49 56 92 30 2 10 39";
            string testlist1 = "0 28 3 49";
            // BST userBST = new BST(userList);
            BST userBST = new BST(testlist1);
            userBST.Print();
            Console.WriteLine();
            userBST.Statistics();
            Console.WriteLine("Please enter a key");
            Console.ReadKey();
        }
    }
}
