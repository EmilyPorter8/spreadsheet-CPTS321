// <copyright file="OperandNodeFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// factory class to create operand node based on user inputted tokens.
    /// </summary>
    internal class OperandNodeFactory
    {
        /// <summary>
        /// Creates type of operand node depending on the string input.
        /// </summary>
        /// <param name="token">
        /// token from user input.
        /// </param>
        /// <returns>
        /// node of correct type.
        /// </returns>
        public Node CreateOperandNode(string token)
        {
            Node curNode = null;
            if (int.TryParse(token, out int newValue))
            {
                // add new constant node.
                curNode = new ConstantNode(token);
            }
            else
            {
                // add new variable node.
                curNode = new VariableNode(token);
            }

            return curNode;
        }
    }
}
