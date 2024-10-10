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
    using System.Threading.Tasks;

    internal class ExpressionTree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// constructor that will make tree from expression.
        /// </summary>
        /// <param name="expression">
        /// the string the user inputs that will be created into tree.
        /// </param>
        public ExpressionTree(string expression)
        {
            // construct tree
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
            // skeleton code for setvariable.
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
            return 0;
        }
    }
}
