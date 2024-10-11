// <copyright file="OperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612.

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Binary operator node, always has two children.
    /// Ex: + , - , *, / .
    /// </summary>
    internal class OperatorNode : Node
    {
        private char value;
        private Node left;
        private Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Constructor inherited from Node. It converts object to character for operator.
        /// </summary>
        /// <param name="value">
        /// the operator.
        /// </param>
        public OperatorNode(string value)
            : base(value)
        {
            this.value = value[0];
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Constructor inherited from Node. It converts object to character for operator.
        /// </summary>
        /// <param name="value">
        /// the operator.
        /// </param>
        /// <param name="newLeft">
        /// the new left child node.
        /// </param>
        /// <param name="newRight">
        /// the new right child node.
        /// </param>
        public OperatorNode(string value, Node newLeft, Node newRight)
            : base(value)
        {
            this.value = value[0];
            this.left = newLeft;
            this.right = newRight;
        }

        /// <summary>
        /// Gets or sets left child node of operator node.
        /// </summary>
        public Node Left
        {
            get => this.left;
            set => this.left = value;
        }

        /// <summary>
        /// Gets or sets right child node of operator node.
        /// </summary>
        public Node Right
        {
            get => this.right;
            set => this.right = value;
        }

        /// <summary>
        /// Overriding the abstract function in Node for operator. This is where bulk of operation will be happening.
        /// Based on value of node, using different operator. Recursive call to left and right child nodes to find their values.
        /// </summary>
        /// <param name="variables">
        /// user inputted variables.
        /// </param>
        /// <returns>
        /// the evaluated result of child nodes and current node.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Dont really know how to use this, but VS autocorrected me when I was typing the default and it seems correct to throw
        /// an exception when there is an invalid operator.
        /// </exception>
        public override double Evaluate(Dictionary<string, double> variables)
        {
            double leftValue = 0;
            double rightValue = 0;

            if (this.left != null) // this should not be null since leaf nodes are either constant or variable nodes.
            {
                leftValue = this.left.Evaluate(variables); // traverse left.
            }

            if (this.right != null)
            {
                rightValue = this.right.Evaluate(variables); // traverse right.
            }

            // what operator are we using.
            switch (this.value)
            {
                case '+':
                    return leftValue + rightValue;
                case '-':
                    return leftValue - rightValue;
                case '*':
                    return leftValue * rightValue;
                case '/':
                    if (rightValue == 0)
                    {
                        return double.PositiveInfinity; // cannot divide by zero.
                    }
                    else
                    {
                        return leftValue / rightValue;
                    }

                default:
                    Console.WriteLine("\nUnavailable operator entered.");
                    throw new NotImplementedException(); // software just autocorrected gave this to me.
            }
        }
    }
}
