//Emily Porter
//011741612
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
        /*************************************************************
        * Attribute: Root                                      
        * Summary:  Root node of the BST         
        * Parameters:                
        * Returns:    N/A                  
        * Exceptions:                                                   
        *************************************************************/
        protected Node Root;

        //constructors
        /*************************************************************
        * Function: BST()                                       
        * Summary:           
        * Parameters:                
        * Returns:    N/A                  
        * Exceptions:                                                   
        *************************************************************/
        public BST() { Root = null; }

        /*************************************************************
        * Function: public BST(string userInput)                                      
        * Summary:  constructor for BST, takes user input, splits it up and converts
        *           to integer, then adds to BST
        * Parameters: needs user input               
        * Returns:    completed tree                  
        * Exceptions:                                                   
        *************************************************************/

        public BST(string userInput) 
        {
            string[] userNumbers= userInput.Split(' '); //split user input into array of strings
            if (userNumbers[0] != "") //check that the user actually inputted something
            {
                foreach (string s in userNumbers) //go through array
                {
                    Add(float.Parse(s)); //add converted array value to tree
                }
            }
            else
            { Root = null; } //if user input is empty, net tree to null
        }


        //functions

        /*************************************************************
        * Function: public void Add(float newData)                                       
        * Summary:  calls Add helper function if root is null, checks for duplicates         
        * Parameters: new data  
        * Returns:  BST with new node with new data               
        * Exceptions:                                                   
        *************************************************************/
        public void Add(float newData)
        {
            //need to check for duplicates
            if (Contains(newData) == false) //check for duplicates
            {
                if (Root != null) //not first node
                {
                    Add(Root, newData); //call helper function
                }
                else
                {
                    Root = new Node(newData); //first node in tree
                }
            }
            else
            { Console.WriteLine("Duplicate of " + newData+" found, not added to tree"); }
        }

        /*************************************************************
        * Function: private void Add(Node pCur, float newData)                                       
        * Summary:  Helper of public Add, finds spot in BST and adds new node         
        * Parameters:  parent node, newData              
        * Returns:    updated tree                  
        * Exceptions:                                                   
        *************************************************************/
        private void Add(Node pCur, float newData)
        {
            if (pCur.Data > newData) //if the tree node data is greater than new data, go left
            {
                if (pCur.Left == null) //if left is empty, add new data to it
                {
                    pCur.Left = new Node(newData); }
                else { 
                    Add(pCur.Left, newData); } //if left isnt empty, call helper and go left
            }
            else { // new data is greater than pCur, go right
                if (pCur.Right == null){ //if right is empty, add it
                    pCur.Right = new Node(newData);
                }
                else { //not empty, go right
                    Add(pCur.Right, newData);
                }
            }
        }

        /*************************************************************
        * Function: public bool Contains(float newData)                                      
        * Summary:  call helper to see if newData already exists in tree     
        * Parameters:  newData              
        * Returns:    bool                  
        * Exceptions:                                                   
        *************************************************************/
        public bool Contains(float newData)
        {
            return Contains(Root, newData); //call helper
        }

        /*************************************************************
        * Function: private bool Contains(Node pCur, float newData)                                      
        * Summary:  Helper of public Contains         
        * Parameters:  parent node, newData              
        * Returns:    bool                 
        * Exceptions:                                                   
        *************************************************************/
        private bool Contains(Node pCur, float newData)
        {
            if (pCur == null) //doesnt have duplicate, return false
            {
                return false;
            }
            else if (pCur.Data == newData) 
            {
                return true; //duplicate found, return true
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


        /*************************************************************
        * Function: public void Print()                                      
        * Summary:  call print helper        
        * Parameters:              
        * Returns:    printed tree                  
        * Exceptions:                                                   
        *************************************************************/
        public void Print() { Console.WriteLine("Least to Greatest in BST:"); Print(Root); }

        /*************************************************************
        * Function: private void Print(Node pCur)                                   
        * Summary:  Helper of public Print, in order traversal, traverses through tree recursivly, printing least to greatest   
        * Parameters:  parent node            
        * Returns:    printed tree                 
        * Exceptions:                                                   
        *************************************************************/
        private void Print(Node pCur)
        {
            if (pCur != null) //check if node is null
            { 
                Print(pCur.Left); //go left (so first value printed will be the least)
                Console.Write(pCur.Data); //print current
                Console.Write(" ");
                Print(pCur.Right); //go right (last value printed will be largest)
            }
        }

        //statistics

        /*************************************************************
        * Function: public void Statistics()                                       
        * Summary:  calls all the statistic functions and prints results        
        * Parameters:            
        * Returns:    printed statistics             
        * Exceptions:                                                   
        *************************************************************/
        public void Statistics()
        {
            
            Console.WriteLine("Statistics:");
            
            Console.WriteLine("Amount of nodes in tree:" + Count(Root));
            Console.WriteLine("Number of levels in tree:" + NumberLevels(Root));
            Console.WriteLine("Possible minimum levels with " + Count(Root) + " node(s):" + PossibleMinLevel(Root));
        }


        /*************************************************************
        * Function: private int Count(Node pCur)                                      
        * Summary:  counts the number of nodes in tree        
        * Parameters:  parent node             
        * Returns:    # of nodes                 
        * Exceptions:                                                   
        *************************************************************/
        private int Count(Node pCur)
        {
            if (pCur == null) //once reach end of branch, return 0
            {
                return 0;
            }
            else {
                return 1 + Count(pCur.Left) + Count(pCur.Right); //count current node, then get totals from children nodes
            }
        }

        /*************************************************************
        * Function:  private int NumberLevels(Node pCur)                                      
        * Summary:  Gets the highest level of tree         
        * Parameters:  parent node             
        * Returns:    highest level              
        * Exceptions:                                                   
        *************************************************************/
        private int NumberLevels(Node pCur)
        {
            if (pCur == null) //reached end of branch, return 0 so it isnt added
            { return 0; }
            else
            {
                int left = NumberLevels(pCur.Left); //recursive call, get the number of levels from left branch
                int right = NumberLevels(pCur.Right); //recursive call, get the mumber of levels from right branch
                if (left > right) //if left has greater number of levels, add current node level, plus those from left child node
                {
                    return 1 + left;
                }
                else //if right has greater number (or equal number) of levels, add current node level, plus those from right child node
                {
                    return 1 + right;
                }
                //return 1 + Math.Max(NumberLevels(pCur.Left), NumberLevels(pCur.Right)); //attempt at smaller algorithm
            }

        }

        /*************************************************************
        * Function: private int PossibleMinLevel(Node pCur)                                       
        * Summary:  from current number of nodes in tree, finds minumum level       
        * Parameters:  root              
        * Returns:    minumim number of levels                 
        * Exceptions:                                                   
        *************************************************************/
        private int PossibleMinLevel(Node pCur)
        {
            double numberNodes = Count(pCur);//grab number of nodes, need to be double(?) to add to log function
            //My original equation was the number of nodes = 2^(min level) - 1. So if there were 7 nodes, the minumum level would be 3. 
            //had to rewrite equation, so the change in variable number of nodes would result in the minimum level: min level = log(base 2) (number of nodes +1)
            //had to cast result to integer and use Math.Ceiling to round to next highest integer. 
            return (int)Math.Ceiling(Math.Log((numberNodes + 1), 2)); 
        }


    }
}
