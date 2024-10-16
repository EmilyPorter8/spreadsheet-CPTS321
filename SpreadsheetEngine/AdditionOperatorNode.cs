// <copyright file="AdditionOperatorNode.cs" company="PlaceholderCompany">
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
    /// Inherits from abstract operator node base class. This differs from parent since it adds the two child nodes in evaluate.
    /// </summary>
    internal class AdditionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionOperatorNode"/> class.
        /// Constructor inherited from OperatorNode. Not really necassary.
        /// </summary>
        public AdditionOperatorNode()
            : base("+")
        {
        }

        /// <summary>
        /// Overriding the abstract function in Node for addition.  Recursive call to left and right child nodes to find their values and add them.
        /// </summary>
        /// <param name="variables">
        /// user inputted variables.
        /// </param>
        /// <returns>
        /// the evaluated result of child nodes and current node.
        /// </returns>
        public override double Evaluate(Dictionary<string, double> variables)
        {
            return this.Left.Evaluate(variables) + this.Right.Evaluate(variables);
        }
    }
}
