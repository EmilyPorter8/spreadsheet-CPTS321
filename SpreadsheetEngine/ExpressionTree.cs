// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612.
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SpreadsheetTests")]

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Class with entire expression tree.
    /// For HW5, this just supports one operator at a time.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// dictionary of user inputted variables.
        /// </summary>
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// root of expression tree.
        /// </summary>
        private OperatorNode root;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// constructor that will make tree from expression.
        /// </summary>
        /// <param name="expression">
        /// the string the user inputs that will be created into tree.
        /// </param>
        public ExpressionTree(string expression)
        {
            List<Node> nodes = new List<Node>();
            nodes = this.ShuntingYard(expression); // configure expression to postfix.
            this.ConstructTree(nodes); // construct tree from postfix.
        }

        /// <summary>
        /// Sets the specified variable withing the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">
        /// string of the variable name we are going to set.
        /// </param>
        /// <param name="doubleValue">
        /// value that variable will be set to.
        /// </param>
        public void SetVariable(string variableName, double doubleValue)
        {
            this.variables[variableName] = doubleValue; // adding variable to dictionary.
        }

        /// <summary>
        /// Check if tree root is null.
        /// </summary>
        /// <returns>
        /// Returns true if it is null, false otherwise.
        /// </returns>
        public bool IsRootNull()
        {
            if (this.root == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// public evaluation function that takes no parameters, but
        /// returns the value of expression as a double.
        /// </summary>
        /// <returns>
        /// value of expression.
        /// </returns>
        public double Evaluate()
        {
            if (this.root != null)
            {
                double result = this.root.Evaluate(this.variables);

                return result;
            }
            else
            {
                Console.WriteLine("Tree is null. Cannot evaluate.");
                return double.NaN; // what should I replace this with? Have not learned error handeling yet.
            }
        }

        /// <summary>
        /// This is a test implementation of Shunting Yard algorithm.  TODO fix.
        /// </summary>
        /// <param name="expression">
        /// user inputted infix expression.
        /// </param>
        /// <returns>
        /// postfix expession.
        /// </returns>
        internal List<Node> ShuntingYard(string expression)
        {
            string curToken = string.Empty;
            Node curNode = null;
            OperatorNodeFactory operatorNodeFactory = new OperatorNodeFactory();
            OperandNodeFactory operandNodeFactory = new OperandNodeFactory();
            List<Node> output = new List<Node>(); // postfix expression of nodes.
            Stack<char> operatorNodes = new Stack<char>(); // shunting yard operator stack.

            // iterate through each character in expression.
            for (int index = 0; index < expression.Length; index++)
            {
                char i = expression[index]; // i is the current char.

                if ((i <= 'Z' && i >= 'A') || (i <= 'z' && i >= 'a') || (i - '0' <= 9 && i - '0' >= 0))
                {
                    // this is a number or char
                    curToken += i;
                }
                else
                {
                    // curToken should be null if parentheses.
                    if (i == '(')
                    {
                        if (curToken != string.Empty) // this is multiplication. for 3(1+2) type expressions.
                        {
                            operatorNodes.Push('*');
                            curNode = operandNodeFactory.CreateOperandNode(curToken);
                            output.Add(curNode);
                            curToken = string.Empty;
                        }

                        operatorNodes.Push('(');
                    }
                    else
                    {
                        // must be an operator, parenthesis, or end.
                        // operand at the end of the expression that doesn't get parsed.
                        if (curToken != string.Empty)
                        {
                            curNode = operandNodeFactory.CreateOperandNode(curToken);
                            output.Add(curNode);
                            curToken = string.Empty;
                        }

                        if (i == ')')
                        {
                            // time to pop until (.
                            bool successParentheses = false;
                            while (operatorNodes.Count != 0 && successParentheses == false) // pop from operatorNodes until other side of parentheses is found.
                            {
                                char op = operatorNodes.Pop(); // take first operator.
                                if (op == '(')
                                {
                                    successParentheses = true; // we are done popping from stack.
                                }
                                else // add op to output.
                                {
                                    OperatorNode tempOp = operatorNodeFactory.CreateOperatorNode(op);
                                    if (tempOp != null)
                                    {
                                        output.Add(operatorNodeFactory.CreateOperatorNode(op));
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nShunting Yard Error: Operator not found."); // operator inputted by user is not avaliable operator.
                                        return null;
                                    }
                                }
                            }

                            if (successParentheses == false)
                            {
                                // reached the end of the stack without finding (, so expression is not balanced.
                                Console.WriteLine("\nShunting Yard Error: Expression is not balanced. Could not find matching '(' symbol.");
                                return null;
                            }
                        }

                        // this is an operator.
                        else
                        {
                            OperatorNode curOp = operatorNodeFactory.CreateOperatorNode(i); // create OperatorNode from current spot in expression.
                            if (curOp != null)
                            {
                                if (operatorNodes.Count != 0 && operatorNodes.Peek() != '(') // if stack is empty, push curOp onto stack.
                                {
                                    OperatorNode stackOp = operatorNodeFactory.CreateOperatorNode(operatorNodes.Peek()); // dont want to pop just yet.

                                    // three possible options
                                    // Option 1: stack is empty or '(' is already covered in line 171.
                                    if (stackOp == null)
                                    {
                                        // operator on node is not a supported operator type.
                                        Console.WriteLine("\nShunting Yard Error: Something went wrong when trying to push/pop onto operator stack.");
                                        return null;
                                    }

                                    // Option 2.
                                    // incoming operator has higher precedence, or same procedence and right associative
                                    else if ((curOp.Precedence > stackOp.Precedence) || (curOp.Precedence == stackOp.Precedence && curOp.Association == "right"))
                                    {
                                        // push
                                        operatorNodes.Push(i);
                                    }

                                    // Option 3.
                                    // incoming operator has lower precedence, or same procedence and left associative
                                    else if ((curOp.Precedence < stackOp.Precedence) || (curOp.Precedence == stackOp.Precedence && curOp.Association == "left"))
                                    {
                                        // pop until incoming has higher precedence, then push it.
                                        while (operatorNodes.Count != 0 && curOp.Precedence <= operatorNodeFactory.CreateOperatorNode(operatorNodes.Peek()).Precedence)
                                        {
                                            char op = operatorNodes.Pop();
                                            stackOp = operatorNodeFactory.CreateOperatorNode(op);
                                            output.Add(stackOp); // add the higher precedent stack operator to output.
                                        }

                                        operatorNodes.Push(i);
                                    }
                                    else
                                    {
                                        // something has gone wrong.
                                        Console.WriteLine("\nShunting Yard Error: Something random went wrong.");
                                        return null;
                                    }
                                }
                                else
                                {
                                    // if stack is empty, push curOp onto stack.
                                    operatorNodes.Push(i);
                                }
                            }
                            else
                            {
                                // something has gone wrong.
                                Console.WriteLine("\nShunting Yard Error: Something went wrong when trying to push/pop onto operator stack.");
                                return null;
                            }
                        }
                    }
                }
            }

            if (curToken != string.Empty) // operand at the end of the expression that doesn't get parsed.
            {
                curNode = operandNodeFactory.CreateOperandNode(curToken);
                output.Add(curNode);
                curToken = string.Empty;
            }

            // check if there is anymore operators in stack.
            while (operatorNodes.Count != 0)
            {
                char op = operatorNodes.Pop();

                if (op != '(')
                {
                    OperatorNode tempOperator = operatorNodeFactory.CreateOperatorNode(op);
                    output.Add(operatorNodeFactory.CreateOperatorNode(op));
                }
                else
                {
                    // operator inputted by user is not avaliable operator or ( is encountered.
                    Console.WriteLine("\nShunting Yard Error: Operator not found or mismatched parentheses.");
                    return null;
                }
            }

            return output;
        }

        /// <summary>
        /// Takes list of nodes in postfix notation and constructs the expression tree from it. Uses stack
        /// to hold the different parts of tree, and at the end of function the finished tree is combined parts
        /// of stack.
        /// </summary>
        /// <param name="nodes">
        /// pstfix notation of user inputted expression in node form.
        /// </param>
        internal void ConstructTree(List<Node> nodes)
        {
            Stack<Node> tree = new Stack<Node>(); // this is where tree parts will be added.
            if (nodes != null) // expression isnt null.
            {
                foreach (Node node in nodes) // iterate through the postfix expression.
                {
                    if (node is OperatorNode)
                    {
                        if (tree.Count >= 2) // make sure that there are enough parts of tree on stack to use for operator.
                        {
                            OperatorNode curOp = (OperatorNode)node;
                            curOp.Right = tree.Pop();
                            curOp.Left = tree.Pop();
                            tree.Push(curOp); // push new part of tree onto stack.
                        }
                        else
                        {
                            Console.WriteLine("Tree cannot be constructed. Wrong number of operators.");
                            this.root = null;
                            return;
                        }
                    }
                    else
                    {
                        tree.Push(node); // not an operator, so an operand.
                    }
                }

                this.root = (OperatorNode)tree.Pop(); // tree is the final combination of different parts from stack.
            }
            else
            {
                Console.WriteLine("Tree cannot be constructed.");
                this.root = null;
                return;
            }
        }
    }
}