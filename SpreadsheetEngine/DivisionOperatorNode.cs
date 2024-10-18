// <copyright file="DivisionOperatorNode.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Inherits from abstract operator node base class. This differs from parent since it divides two child nodes in evaluate.
    /// </summary>
    internal class DivisionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionOperatorNode"/> class.
        /// Constructor inherited from OperatorNode.
        /// </summary>
        public DivisionOperatorNode()
            : base("/", 1, "left")
        {
        }

        /// <summary>
        /// Overriding the abstract function in Node for operator.  Recursive call to left and right child nodes to find their values and divide them.
        /// </summary>
        /// <param name="variables">
        /// user inputted variables.
        /// </param>
        /// <returns>
        /// the evaluated result of child nodes and current node.
        /// </returns>
        public override double Evaluate(Dictionary<string, double> variables)
        {
            double leftValue = this.Left.Evaluate(variables);
            double rightValue = this.Right.Evaluate(variables);
            if (rightValue == 0)
            {
                return double.PositiveInfinity; // cannot divide by zero.
            }
            else
            {
                return leftValue / rightValue;
            }
        }
    }
}
