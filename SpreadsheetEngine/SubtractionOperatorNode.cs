// <copyright file="SubtractionOperatorNode.cs" company="PlaceholderCompany">
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
    /// Inherits from abstract operator node base class. This differs from parent since it subtracts one child from another in evaluate.
    /// </summary>
    internal class SubtractionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionOperatorNode"/> class.
        /// Constructor inherited from OperatorNode.
        /// </summary>
        public SubtractionOperatorNode()
            : base("-", 0, "left")
        {
        }

        /// <summary>
        /// Overriding the abstract function in Node for operator.  Recursive call to left and right child nodes to find their values and subtract one from another.
        /// </summary>
        /// <param name="variables">
        /// user inputted variables.
        /// </param>
        /// <returns>
        /// the evaluated result of child nodes and current node.
        /// </returns>
        public override double Evaluate(Dictionary<string, double> variables)
        {
            return this.Left.Evaluate(variables) - this.Right.Evaluate(variables);
        }
    }
}
