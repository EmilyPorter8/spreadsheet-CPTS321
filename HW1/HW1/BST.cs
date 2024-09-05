using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class BST
    {
        //members
        protected Node Root;

        //constructors
        public BST() { }
        public BST(string userInput) 
        {
            string[] userNumbers= userInput.Split(' ');
            if (userNumbers[0] != "")
            {
                foreach (string s in userNumbers)
                {
                    Add(float.Parse(s));
                }
            }
            else
            { Root = null; }
        }


        //functions
        public void Add(float newData)
        {
            //need to check for duplicates
            if (Contains(newData) == false)
            {
                if (Root != null)
                {
                    Add(Root, newData);
                }
                else
                {
                    Root = new Node(newData);
                }
            }
            else
            { Console.WriteLine("Duplicate of " + newData+" found, not added to tree"); }
        }
        private void Add(Node pCur, float newData)
        {
            if (pCur.Data > newData)
            {
                if (pCur.Left == null)
                {
                    pCur.Left = new Node(newData); }
                else { 
                    Add(pCur.Left, newData); }
            }
            else { // new data is greater than pCur
                if (pCur.Right == null){ 
                    pCur.Right = new Node(newData);
                }
                else { 
                    Add(pCur.Right, newData);
                }
            }
        }

        public bool Contains(float newData)
        {
            return Contains(Root, newData); //call helper
        }
        private bool Contains(Node pCur, float newData)
        {
            if (pCur == null)
            {
                return false;
            }
            else if (pCur.Data == newData)
            {
                return true;
            }
            else {
                if (pCur.Data < newData)
                {
                    //newData is greater than Node's data, so go right
                    return Contains(pCur.Right, newData);
                }
                else
                {
                    //go left
                    return Contains(pCur.Left, newData);

                }
            }
        }

        public void Print() { Console.WriteLine("Least to Greatest in BST:"); Print(Root); }
        private void Print(Node pCur)
        {
            if (pCur != null)
            { Print(pCur.Left);
                Console.Write(pCur.Data);
                Console.Write(" ");
                Print(pCur.Right);
            }
        }

        //statistics
        public void Statistics()
        {
            
            Console.WriteLine("Statistics:");
            
            Console.WriteLine("Amount of nodes in tree:" + Count(Root));
            
        }

        private int Count(Node pCur)
        {
            if (pCur == null)
            {
                return 0;
            }
            else {
                return 1 + Count(pCur.Left) + Count(pCur.Right);
            }
        }


      
    }
}
