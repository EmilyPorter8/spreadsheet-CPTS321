// <copyright file="Node.cs" company="PlaceholderCompany">
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
    /// Abstract base class for rest of node types to inherit from.
    /// </summary>
    public abstract class Node
    {
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">
        /// The value of the node we are constructing. For example, for operator node, value could be  '+'.
        /// </param>
        public Node(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// Sets value to empty.
        /// </summary>
        public Node()
        {
            this.value = string.Empty;
        }

        /// <summary>
        /// Gets value, property Value that can get value.
        /// </summary>
        public object Value { get => this.value; }

        /// <summary>
        /// This is the evaluate that should be overwritten by child Node classes.
        /// </summary>
        /// <param name="variables">
        /// user set variables.
        /// </param>
        /// <returns>
        /// should return corresponding value.
        /// </returns>
        public abstract double Evaluate(Dictionary<string, double> variables);
    }
}
