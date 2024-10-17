// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612.

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Class with entire expression tree.
    /// For HW5, this just supports one operator at a time.
    /// </summary>
    public class ExpressionTree
    {
        private Dictionary<string, double> variables = new Dictionary<string, double>();
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
            string curToken = string.Empty;
            Node curNode = null;
            OperatorNodeFactory operatorNodeFactory = new OperatorNodeFactory();
            OperandNodeFactory operandNodeFactory = new OperandNodeFactory();
            List<Node> output = new List<Node>(); // postfix expression of nodes.
            Stack<OperatorNode> operatorNodes = new Stack<OperatorNode>(); // shunting yard operator stack.

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
                    // must be an operator or end.

                    // create operand node.
                    curNode = operandNodeFactory.CreateOperandNode(curToken);

                    curToken = string.Empty; // we are done with reading this token, so set it to empty.

                    if (this.root == null) // there is no root
                    {
                        this.root = operatorNodeFactory.CreateOperatorNode(i);
                        this.root.Left = curNode;
                    }
                    else // root is not empty, so need to shift everything to the left
                    {
                        this.root.Right = curNode; // left is occupied, so new information goes right.
                        OperatorNode newRoot = operatorNodeFactory.CreateOperatorNode(i); // construct newRoot.
                        newRoot.Left = this.root; // move root to the left child of newRoot
                        this.root = newRoot; // set root to newRoot.
                    }
                }
            }

            if (curToken != null || curToken != string.Empty) // operand at the end of the expression that doesn't get parsed.
            {
                curNode = operandNodeFactory.CreateOperandNode(curToken);
                this.root.Right = curNode;
            }
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
        /// public evaluation function that takes no parameters, but
        /// returns the value of expression as a double.
        /// </summary>
        /// <returns>
        /// value of expression.
        /// </returns>
        public double Evaluate()
        {
            double result = this.root.Evaluate(this.variables);

            return result;
        }
    }
}
