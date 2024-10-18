// <copyright file="ConstantNode.cs" company="PlaceholderCompany">
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
    /// Constant value node, like 3.
    /// </summary>
    internal class ConstantNode : Node
    {
        private double value; // value of constant node, should always be a double or integer.

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// Constructor inherited from Node. It converts object to character for operator.
        /// </summary>
        /// <param name="value">
        /// the operator.
        /// </param>
        public ConstantNode(string value)
            : base(value)
        {
            this.value = double.Parse(value);
        }

        /// <summary>
        /// Overrridden evaluate function, just returns the value of node.
        /// </summary>
        /// <param name="variables">
        /// User inputted variables.
        /// </param>
        /// <returns>
        /// just returns the value of the node.
        /// </returns>
        public override double Evaluate(Dictionary<string, double> variables)
        {
            return this.value;
        }
    }
}
