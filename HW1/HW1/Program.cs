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
            string userList = Console.ReadLine();
            BST userBST = new BST(userList);
            //call BST
            userBST.Print();
            Console.ReadKey();
        }
    }
}
